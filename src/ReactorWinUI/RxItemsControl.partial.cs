using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Linq;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Media3D;

using Windows.UI.Text;
using Windows.Foundation;

using ReactorWinUI.Internals;
using Microsoft.UI.Xaml.Markup;

namespace ReactorWinUI
{
    public partial interface IRxItemsControl : IRxControl
    {
        PropertyValue<IItemTemplateFactory> ItemTemplate { get; set; }
        PropertyValue<IEnumerable> ItemsSource { get; set; }
    }

    public partial class RxItemsControl<T>
    {
        PropertyValue<IItemTemplateFactory> IRxItemsControl.ItemTemplate { get; set; }
        PropertyValue<IEnumerable> IRxItemsControl.ItemsSource { get; set; }


        partial void OnBeginUpdate()
        {
            var thisAsIRxItemsControl = (IRxItemsControl)this;
            //NativeControl.Set(ItemsControl.ItemTemplateProperty, thisAsIRxLayoutable.ItemTemplate);
            //var previousItemTemplate = NativeControl.ItemTemplate as IItemTemplate;

            //NativeControl.ItemTemplate = thisAsIRxLayoutable.ItemTemplate?.Value;

            //if (NativeControl.ItemTemplate is IItemTemplate currentItemTemplate)
            //{
            //    currentItemTemplate.PreviousTemplate = previousItemTemplate;
            //}

            //NativeControl.ItemTemplate = thisAsIRxItemsControl.ItemTemplate?.Value;

            //Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name);

            //new ItemTemplatePresenter();
            //if (NativeControl.ItemTemplate == null)
            //{
            //    NativeControl.ItemTemplate = ItemTemplatePresenter.DataTemplate;
            //}            

            var itemsSource = thisAsIRxItemsControl.ItemsSource?.Value;

            if (itemsSource != null)
            {
                if (NativeControl.ItemsSource != itemsSource)
                {
                    NativeControl.ItemTemplate = ItemTemplatePresenter.CreateDataTemplate(thisAsIRxItemsControl.ItemTemplate.Value);
                    NativeControl.ItemsSource = itemsSource;
                }
            }
            else
            {
                NativeControl.ItemsSource = null;
            }
        }
    }

    internal class ItemsSourceWrapper : IReadOnlyList<object>
    {
        private readonly IReadOnlyList<object> _internalList;

        public ItemsSourceWrapper(IEnumerable itemsSource)
        {
            _internalList = itemsSource.Cast<object>().ToList();
            ItemsSource = itemsSource;
        }

        public IEnumerable ItemsSource { get; }

        public object this[int index] => _internalList[index];

        public int Count => _internalList.Count;

        public IEnumerator<object> GetEnumerator() => _internalList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _internalList.GetEnumerator();
    }

    internal class ItemTemplateNode : VisualNode
    {
        public ItemTemplateNode()
        {
        }

        private VisualNode _root;

        public VisualNode Root
        {
            get => _root;
            set
            {
                if (_root != value)
                {
                    _root = value;
                    Invalidate();
                }
            }
        }

        public UIElement RootControl { get; private set; }

        protected sealed override void OnAddChild(VisualNode widget, object nativeControl)
        {
            if (nativeControl is UIElement view)
                RootControl = view;
            else
            {
                throw new InvalidOperationException($"Type '{nativeControl.GetType()}' not supported under '{GetType()}'");
            }
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object nativeControl)
        {
            RootControl = null;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Root;
        }

        protected internal override void OnLayoutCycleRequested()
        {
            Layout();
            base.OnLayoutCycleRequested();
        }
    }

    public class ItemTemplatePresenter : ContentControl
    {
        private static Dictionary<Guid, (DataTemplate, IItemTemplateFactory)> _templates = new Dictionary<Guid, (DataTemplate, IItemTemplateFactory)>();
        internal static DataTemplate CreateDataTemplate(IItemTemplateFactory templateFactory)
        {
            Guid itemsSourceId = Guid.NewGuid();
            var templatePair = ((DataTemplate)XamlReader.Load($@"
                <DataTemplate 
                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                    xmlns:reactorwinui=""using:ReactorWinUI"">
                    <reactorwinui:ItemTemplatePresenter ItemsSourceId=""{itemsSourceId}""/>
                </DataTemplate>"), templateFactory);//

            _templates.Add(itemsSourceId, templatePair);

            return templatePair.Item1;
        }

        internal static bool RemoveTemplate(Guid itemsSourceId)
            => _templates.Remove(itemsSourceId);

        private ItemTemplateNode _currentItemTemplateNode;



        public string ItemsSourceId
        {
            get { return (string)GetValue(ItemsSourceIdProperty); }
            set { SetValue(ItemsSourceIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSourceId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceIdProperty =
            DependencyProperty.Register("ItemsSourceId", typeof(string), typeof(ItemTemplatePresenter), new PropertyMetadata(null));

        object _oldContext;

        public ItemTemplatePresenter()
        {
            DataContextChanged += ItemTemplatePresenter_DataContextChanged;            
        }

        private void ItemTemplatePresenter_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            args.Handled = true;

            if (_oldContext == args.NewValue)
                return;

            if (args.NewValue != null)
            {
                if (!_templates.TryGetValue(Guid.Parse(ItemsSourceId), out var templatePair))
                {
                    throw new InvalidOperationException();
                }

                _currentItemTemplateNode ??= new ItemTemplateNode();
                _currentItemTemplateNode.Root = templatePair.Item2.GetRootVisualNode(args.NewValue);
                _currentItemTemplateNode.Layout();

                Content = _currentItemTemplateNode.RootControl;
            }
            else
            {
                _currentItemTemplateNode = null;
                Content = null;
            }

            _oldContext = args.NewValue;
        }


        //private void ItemTemplatePresenter_DataContextChanged1(FrameworkElement sender, DataContextChangedEventArgs args)
        //{
        //    var itemTemplate = (ItemTemplate<I>)((ContentPresenter)sender).ContentTemplate;
        //    var newRoot = itemTemplate.RenderFunc((I)args.NewValue);

        //    var previousTemplateNode = itemTemplate.PreviousTemplate?.GetAvailableTemplateNode();

        //    if (previousTemplateNode != null)
        //    {
        //        previousTemplateNode.Root = newRoot;
        //        previousTemplateNode.Layout();
        //        itemTemplate.RegisterTemplate(previousTemplateNode);
        //        Content = previousTemplateNode.RootControl;
        //    }
        //    else
        //    {
        //        var itemTemplateNode = new ItemTemplateNode(newRoot);
        //        itemTemplateNode.Layout();
        //        itemTemplate.RegisterTemplate(itemTemplateNode);
        //        Content = itemTemplateNode.RootControl;
        //    }
        //}
    }

    //internal interface IItemTemplate
    //{
    //    IItemTemplate PreviousTemplate { get; set; }

    //    ItemTemplateNode GetAvailableTemplateNode();

    //    void RegisterTemplate(ItemTemplateNode itemTemplateNode);
    //}

    //internal class ItemTemplatePresenter<I> : ContentControl
    //{
    //    public ItemTemplatePresenter()
    //    {
    //        DataContextChanged += ItemTemplatePresenter_DataContextChanged1;
    //    }

    //    private void ItemTemplatePresenter_DataContextChanged1(FrameworkElement sender, DataContextChangedEventArgs args)
    //    {
    //        var itemTemplate = (ItemTemplate<I>)((ContentPresenter)sender).ContentTemplate;
    //        var newRoot = itemTemplate.RenderFunc((I)args.NewValue);

    //        var previousTemplateNode = itemTemplate.PreviousTemplate?.GetAvailableTemplateNode();

    //        if (previousTemplateNode != null)
    //        {
    //            previousTemplateNode.Root = newRoot;
    //            previousTemplateNode.Layout();
    //            itemTemplate.RegisterTemplate(previousTemplateNode);
    //            Content = previousTemplateNode.RootControl;
    //        }
    //        else
    //        {
    //            var itemTemplateNode = new ItemTemplateNode(newRoot);
    //            itemTemplateNode.Layout();
    //            itemTemplate.RegisterTemplate(itemTemplateNode);
    //            Content = itemTemplateNode.RootControl;
    //        }
    //    }
    //}

    //internal interface IItemTemplate
    //{
    //    IItemTemplate PreviousTemplate { get; set; }

    //    ItemTemplateNode GetAvailableTemplateNode();

    //    void RegisterTemplate(ItemTemplateNode itemTemplateNode);
    //}

    //internal class ItemWrapper : IEquatable<ItemWrapper>
    //{
    //    public ItemWrapper(object item, IItemTemplateFactory itemTemplateFactory)
    //    {
    //        Item = item;
    //        ItemTemplateFactory = itemTemplateFactory;
    //    }

    //    public object Item { get; }
    //    public IItemTemplateFactory ItemTemplateFactory { get; }
    //}

    public interface IItemTemplateFactory
    {
        VisualNode GetRootVisualNode(object item);
    }

    internal class ItemTemplateFactory<I> : IItemTemplateFactory//, IItemTemplate
    {
        private Queue<ItemTemplateNode> _availableItemTemplates = new Queue<ItemTemplateNode>();

        public ItemTemplateFactory(Func<I, VisualNode> renderFunc)
        {
            RenderFunc = renderFunc;
        }

        public VisualNode GetRootVisualNode(object item)
        {
            return RenderFunc((I)item);

            //itemTemplate.RegisterTemplate(itemTemplateNode);
            //Content = itemTemplateNode.RootControl;

        }

        //public void RecycleElement(Microsoft.UI.Xaml.ElementFactoryRecycleArgs args)
        //{
            
        //}

        public Func<I, VisualNode> RenderFunc { get; }

        public Type ItemType => typeof(I);

        //public IItemTemplate PreviousTemplate { get; set; }

        public ItemTemplateNode GetAvailableTemplateNode()
        {
            if (_availableItemTemplates.TryDequeue(out var itemTemplateNode))
                return itemTemplateNode;

            return null;
        }

        public void RegisterTemplate(ItemTemplateNode itemTemplateNode)
        {
            _availableItemTemplates.Enqueue(itemTemplateNode);
        }
    }

    public static partial class RxItemsControlExtensions
    {
        public static T ItemsSource<T>(this T itemscontrol, IEnumerable itemsSource) where T : IRxItemsControl
        {
            itemscontrol.ItemsSource = new PropertyValue<IEnumerable>(itemsSource);
            return itemscontrol;
        }

        public static T OnRenderItem<T, I>(this T itemscontrol, Func<I, VisualNode> renderFunc) where T : IRxItemsControl
        {
            itemscontrol.ItemTemplate = new PropertyValue<IItemTemplateFactory>(new ItemTemplateFactory<I>(renderFunc));

            return itemscontrol;
        }
    }
}
