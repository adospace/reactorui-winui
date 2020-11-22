using Microsoft.UI.Xaml;
using ReactorWinUI.Internals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;

namespace ReactorWinUI
{
    public partial interface IRxWindow
    {
        PropertyValue<string> Title { get; set; }
    }

    public class RxWindow : VisualNode, IEnumerable<VisualNode>, IRxWindow
    {
        private readonly List<VisualNode> _contents = new();
        private readonly Action<Window> _componentRefAction;
        private Window _nativeControl;

        PropertyValue<string> IRxWindow.Title { get; set; }

        public RxWindow()
        {

        }

        public RxWindow(Action<Window> componentRefAction)
        {
            _componentRefAction = componentRefAction;
        }

        public RxWindow(VisualNode content)
        {
            _contents.Add(content);
        }

        public RxWindow(string title)
        {
            this.Title(title);
        }

        protected override void OnMount()
        {
            _nativeControl = new Window();
            _nativeControl.Activate();
            //m_windowhandle = PInvoke.User32.GetActiveWindow();

            Parent?.AddChild(this, _nativeControl);
            _componentRefAction?.Invoke(_nativeControl);

            base.OnMount();
        }

        protected override void OnUnmount()
        {
            _nativeControl.Close();

            base.OnUnmount();
        }

        public void Add(VisualNode child)
        {
            if (child is VisualNode && _contents.Any())
                throw new InvalidOperationException("Content already set");

            _contents.Add(child);
        }

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _contents.GetEnumerator();
        }

        protected override void OnAddChild(VisualNode widget, object childControl)
        {
            if (childControl is UIElement rootElement)
            {
                _nativeControl.Content = rootElement;
            }
            else
            {
                throw new NotSupportedException($"Content of window must be an UIElement ({childControl.GetType()} received instead)");
            }

            base.OnAddChild(widget, childControl);
        }

        protected override void OnRemoveChild(VisualNode widget, object childControl)
        {
            _nativeControl.Content = null;

            base.OnRemoveChild(widget, childControl);
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _contents;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        protected override void OnUpdate()
        {
            var thisAsIRxWindow = (IRxWindow)this;
            _nativeControl.Title = thisAsIRxWindow.Title?.Value;

            base.OnUpdate();
        }
    }
    
    public static partial class RxWindowExtensions
    {
        public static T Title<T>(this T window, string title) where T : IRxWindow
        {
            window.Title = new PropertyValue<string>(title);
            return window;
        }
    }
}
