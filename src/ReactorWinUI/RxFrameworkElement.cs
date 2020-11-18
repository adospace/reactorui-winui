using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Reflection;


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

namespace ReactorWinUI
{
    public partial interface IRxFrameworkElement : IRxUIElement
    {
        PropertyValue<bool> AllowFocusOnInteraction { get; set; }
        PropertyValue<bool> AllowFocusWhenDisabled { get; set; }
        PropertyValue<object> DataContext { get; set; }
        PropertyValue<FlowDirection> FlowDirection { get; set; }
        PropertyValue<Thickness> FocusVisualMargin { get; set; }
        PropertyValue<Brush> FocusVisualPrimaryBrush { get; set; }
        PropertyValue<Thickness> FocusVisualPrimaryThickness { get; set; }
        PropertyValue<Brush> FocusVisualSecondaryBrush { get; set; }
        PropertyValue<Thickness> FocusVisualSecondaryThickness { get; set; }
        PropertyValue<double> Height { get; set; }
        PropertyValue<HorizontalAlignment> HorizontalAlignment { get; set; }
        PropertyValue<string> Language { get; set; }
        PropertyValue<Thickness> Margin { get; set; }
        PropertyValue<double> MaxHeight { get; set; }
        PropertyValue<double> MaxWidth { get; set; }
        PropertyValue<double> MinHeight { get; set; }
        PropertyValue<double> MinWidth { get; set; }
        PropertyValue<string> Name { get; set; }
        PropertyValue<ElementTheme> RequestedTheme { get; set; }
        PropertyValue<Style> Style { get; set; }
        PropertyValue<object> Tag { get; set; }
        PropertyValue<VerticalAlignment> VerticalAlignment { get; set; }
        PropertyValue<double> Width { get; set; }

        Action LoadedAction { get; set; }
        Action<object, RoutedEventArgs> LoadedActionWithArgs { get; set; }
        Action UnloadedAction { get; set; }
        Action<object, RoutedEventArgs> UnloadedActionWithArgs { get; set; }
    }

    public partial class RxFrameworkElement<T> : RxUIElement<T>, IRxFrameworkElement where T : FrameworkElement, new()
    {
        public RxFrameworkElement()
        {

        }

        public RxFrameworkElement(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<bool> IRxFrameworkElement.AllowFocusOnInteraction { get; set; }
        PropertyValue<bool> IRxFrameworkElement.AllowFocusWhenDisabled { get; set; }
        PropertyValue<object> IRxFrameworkElement.DataContext { get; set; }
        PropertyValue<FlowDirection> IRxFrameworkElement.FlowDirection { get; set; }
        PropertyValue<Thickness> IRxFrameworkElement.FocusVisualMargin { get; set; }
        PropertyValue<Brush> IRxFrameworkElement.FocusVisualPrimaryBrush { get; set; }
        PropertyValue<Thickness> IRxFrameworkElement.FocusVisualPrimaryThickness { get; set; }
        PropertyValue<Brush> IRxFrameworkElement.FocusVisualSecondaryBrush { get; set; }
        PropertyValue<Thickness> IRxFrameworkElement.FocusVisualSecondaryThickness { get; set; }
        PropertyValue<double> IRxFrameworkElement.Height { get; set; }
        PropertyValue<HorizontalAlignment> IRxFrameworkElement.HorizontalAlignment { get; set; }
        PropertyValue<string> IRxFrameworkElement.Language { get; set; }
        PropertyValue<Thickness> IRxFrameworkElement.Margin { get; set; }
        PropertyValue<double> IRxFrameworkElement.MaxHeight { get; set; }
        PropertyValue<double> IRxFrameworkElement.MaxWidth { get; set; }
        PropertyValue<double> IRxFrameworkElement.MinHeight { get; set; }
        PropertyValue<double> IRxFrameworkElement.MinWidth { get; set; }
        PropertyValue<string> IRxFrameworkElement.Name { get; set; }
        PropertyValue<ElementTheme> IRxFrameworkElement.RequestedTheme { get; set; }
        PropertyValue<Style> IRxFrameworkElement.Style { get; set; }
        PropertyValue<object> IRxFrameworkElement.Tag { get; set; }
        PropertyValue<VerticalAlignment> IRxFrameworkElement.VerticalAlignment { get; set; }
        PropertyValue<double> IRxFrameworkElement.Width { get; set; }

        Action IRxFrameworkElement.LoadedAction { get; set; }
        Action<object, RoutedEventArgs> IRxFrameworkElement.LoadedActionWithArgs { get; set; }
        Action IRxFrameworkElement.UnloadedAction { get; set; }
        Action<object, RoutedEventArgs> IRxFrameworkElement.UnloadedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            NativeControl.Set(this, FrameworkElement.AllowFocusOnInteractionProperty, thisAsIRxFrameworkElement.AllowFocusOnInteraction);
            NativeControl.Set(this, FrameworkElement.AllowFocusWhenDisabledProperty, thisAsIRxFrameworkElement.AllowFocusWhenDisabled);
            NativeControl.Set(this, FrameworkElement.DataContextProperty, thisAsIRxFrameworkElement.DataContext);
            NativeControl.Set(this, FrameworkElement.FlowDirectionProperty, thisAsIRxFrameworkElement.FlowDirection);
            NativeControl.Set(this, FrameworkElement.FocusVisualMarginProperty, thisAsIRxFrameworkElement.FocusVisualMargin);
            NativeControl.Set(this, FrameworkElement.FocusVisualPrimaryBrushProperty, thisAsIRxFrameworkElement.FocusVisualPrimaryBrush);
            NativeControl.Set(this, FrameworkElement.FocusVisualPrimaryThicknessProperty, thisAsIRxFrameworkElement.FocusVisualPrimaryThickness);
            NativeControl.Set(this, FrameworkElement.FocusVisualSecondaryBrushProperty, thisAsIRxFrameworkElement.FocusVisualSecondaryBrush);
            NativeControl.Set(this, FrameworkElement.FocusVisualSecondaryThicknessProperty, thisAsIRxFrameworkElement.FocusVisualSecondaryThickness);
            NativeControl.Set(this, FrameworkElement.HeightProperty, thisAsIRxFrameworkElement.Height);
            NativeControl.Set(this, FrameworkElement.HorizontalAlignmentProperty, thisAsIRxFrameworkElement.HorizontalAlignment);
            NativeControl.Set(this, FrameworkElement.LanguageProperty, thisAsIRxFrameworkElement.Language);
            NativeControl.Set(this, FrameworkElement.MarginProperty, thisAsIRxFrameworkElement.Margin);
            NativeControl.Set(this, FrameworkElement.MaxHeightProperty, thisAsIRxFrameworkElement.MaxHeight);
            NativeControl.Set(this, FrameworkElement.MaxWidthProperty, thisAsIRxFrameworkElement.MaxWidth);
            NativeControl.Set(this, FrameworkElement.MinHeightProperty, thisAsIRxFrameworkElement.MinHeight);
            NativeControl.Set(this, FrameworkElement.MinWidthProperty, thisAsIRxFrameworkElement.MinWidth);
            NativeControl.Set(this, FrameworkElement.NameProperty, thisAsIRxFrameworkElement.Name);
            NativeControl.Set(this, FrameworkElement.RequestedThemeProperty, thisAsIRxFrameworkElement.RequestedTheme);
            NativeControl.Set(this, FrameworkElement.StyleProperty, thisAsIRxFrameworkElement.Style);
            NativeControl.Set(this, FrameworkElement.TagProperty, thisAsIRxFrameworkElement.Tag);
            NativeControl.Set(this, FrameworkElement.VerticalAlignmentProperty, thisAsIRxFrameworkElement.VerticalAlignment);
            NativeControl.Set(this, FrameworkElement.WidthProperty, thisAsIRxFrameworkElement.Width);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            if (thisAsIRxFrameworkElement.LoadedAction != null || thisAsIRxFrameworkElement.LoadedActionWithArgs != null)
            {
                NativeControl.Loaded += NativeControl_Loaded;
            }
            if (thisAsIRxFrameworkElement.UnloadedAction != null || thisAsIRxFrameworkElement.UnloadedActionWithArgs != null)
            {
                NativeControl.Unloaded += NativeControl_Unloaded;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Loaded(object sender, RoutedEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.LoadedAction?.Invoke();
            thisAsIRxFrameworkElement.LoadedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Unloaded(object sender, RoutedEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.UnloadedAction?.Invoke();
            thisAsIRxFrameworkElement.UnloadedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.Loaded -= NativeControl_Loaded;
                NativeControl.Unloaded -= NativeControl_Unloaded;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxFrameworkElementExtensions
    {
        public static T AllowFocusOnInteraction<T>(this T frameworkelement, bool allowFocusOnInteraction) where T : IRxFrameworkElement
        {
            frameworkelement.AllowFocusOnInteraction = new PropertyValue<bool>(allowFocusOnInteraction);
            return frameworkelement;
        }
        public static T AllowFocusWhenDisabled<T>(this T frameworkelement, bool allowFocusWhenDisabled) where T : IRxFrameworkElement
        {
            frameworkelement.AllowFocusWhenDisabled = new PropertyValue<bool>(allowFocusWhenDisabled);
            return frameworkelement;
        }
        public static T DataContext<T>(this T frameworkelement, object dataContext) where T : IRxFrameworkElement
        {
            frameworkelement.DataContext = new PropertyValue<object>(dataContext);
            return frameworkelement;
        }
        public static T FlowDirection<T>(this T frameworkelement, FlowDirection flowDirection) where T : IRxFrameworkElement
        {
            frameworkelement.FlowDirection = new PropertyValue<FlowDirection>(flowDirection);
            return frameworkelement;
        }
        public static T FocusVisualMargin<T>(this T frameworkelement, Thickness focusVisualMargin) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualMargin = new PropertyValue<Thickness>(focusVisualMargin);
            return frameworkelement;
        }
        public static T FocusVisualMargin<T>(this T frameworkelement, double leftRight, double topBottom) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualMargin = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return frameworkelement;
        }
        public static T FocusVisualMargin<T>(this T frameworkelement, double uniformSize) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualMargin = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return frameworkelement;
        }
        public static T FocusVisualPrimaryBrush<T>(this T frameworkelement, Brush focusVisualPrimaryBrush) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualPrimaryBrush = new PropertyValue<Brush>(focusVisualPrimaryBrush);
            return frameworkelement;
        }
        public static T FocusVisualPrimaryThickness<T>(this T frameworkelement, Thickness focusVisualPrimaryThickness) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualPrimaryThickness = new PropertyValue<Thickness>(focusVisualPrimaryThickness);
            return frameworkelement;
        }
        public static T FocusVisualPrimaryThickness<T>(this T frameworkelement, double leftRight, double topBottom) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualPrimaryThickness = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return frameworkelement;
        }
        public static T FocusVisualPrimaryThickness<T>(this T frameworkelement, double uniformSize) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualPrimaryThickness = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return frameworkelement;
        }
        public static T FocusVisualSecondaryBrush<T>(this T frameworkelement, Brush focusVisualSecondaryBrush) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualSecondaryBrush = new PropertyValue<Brush>(focusVisualSecondaryBrush);
            return frameworkelement;
        }
        public static T FocusVisualSecondaryThickness<T>(this T frameworkelement, Thickness focusVisualSecondaryThickness) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualSecondaryThickness = new PropertyValue<Thickness>(focusVisualSecondaryThickness);
            return frameworkelement;
        }
        public static T FocusVisualSecondaryThickness<T>(this T frameworkelement, double leftRight, double topBottom) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualSecondaryThickness = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return frameworkelement;
        }
        public static T FocusVisualSecondaryThickness<T>(this T frameworkelement, double uniformSize) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualSecondaryThickness = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return frameworkelement;
        }
        public static T Height<T>(this T frameworkelement, double height) where T : IRxFrameworkElement
        {
            frameworkelement.Height = new PropertyValue<double>(height);
            return frameworkelement;
        }
        public static T HorizontalAlignment<T>(this T frameworkelement, HorizontalAlignment horizontalAlignment) where T : IRxFrameworkElement
        {
            frameworkelement.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(horizontalAlignment);
            return frameworkelement;
        }
        public static T Language<T>(this T frameworkelement, string language) where T : IRxFrameworkElement
        {
            frameworkelement.Language = new PropertyValue<string>(language);
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, Thickness margin) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(margin);
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, double leftRight, double topBottom) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, double uniformSize) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return frameworkelement;
        }
        public static T MaxHeight<T>(this T frameworkelement, double maxHeight) where T : IRxFrameworkElement
        {
            frameworkelement.MaxHeight = new PropertyValue<double>(maxHeight);
            return frameworkelement;
        }
        public static T MaxWidth<T>(this T frameworkelement, double maxWidth) where T : IRxFrameworkElement
        {
            frameworkelement.MaxWidth = new PropertyValue<double>(maxWidth);
            return frameworkelement;
        }
        public static T MinHeight<T>(this T frameworkelement, double minHeight) where T : IRxFrameworkElement
        {
            frameworkelement.MinHeight = new PropertyValue<double>(minHeight);
            return frameworkelement;
        }
        public static T MinWidth<T>(this T frameworkelement, double minWidth) where T : IRxFrameworkElement
        {
            frameworkelement.MinWidth = new PropertyValue<double>(minWidth);
            return frameworkelement;
        }
        public static T Name<T>(this T frameworkelement, string name) where T : IRxFrameworkElement
        {
            frameworkelement.Name = new PropertyValue<string>(name);
            return frameworkelement;
        }
        public static T RequestedTheme<T>(this T frameworkelement, ElementTheme requestedTheme) where T : IRxFrameworkElement
        {
            frameworkelement.RequestedTheme = new PropertyValue<ElementTheme>(requestedTheme);
            return frameworkelement;
        }
        public static T Style<T>(this T frameworkelement, Style style) where T : IRxFrameworkElement
        {
            frameworkelement.Style = new PropertyValue<Style>(style);
            return frameworkelement;
        }
        public static T Tag<T>(this T frameworkelement, object tag) where T : IRxFrameworkElement
        {
            frameworkelement.Tag = new PropertyValue<object>(tag);
            return frameworkelement;
        }
        public static T VerticalAlignment<T>(this T frameworkelement, VerticalAlignment verticalAlignment) where T : IRxFrameworkElement
        {
            frameworkelement.VerticalAlignment = new PropertyValue<VerticalAlignment>(verticalAlignment);
            return frameworkelement;
        }
        public static T Width<T>(this T frameworkelement, double width) where T : IRxFrameworkElement
        {
            frameworkelement.Width = new PropertyValue<double>(width);
            return frameworkelement;
        }
        public static T OnLoaded<T>(this T frameworkelement, Action loadedAction) where T : IRxFrameworkElement
        {
            frameworkelement.LoadedAction = loadedAction;
            return frameworkelement;
        }

        public static T OnLoaded<T>(this T frameworkelement, Action<object, RoutedEventArgs> loadedActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.LoadedActionWithArgs = loadedActionWithArgs;
            return frameworkelement;
        }
        public static T OnUnloaded<T>(this T frameworkelement, Action unloadedAction) where T : IRxFrameworkElement
        {
            frameworkelement.UnloadedAction = unloadedAction;
            return frameworkelement;
        }

        public static T OnUnloaded<T>(this T frameworkelement, Action<object, RoutedEventArgs> unloadedActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.UnloadedActionWithArgs = unloadedActionWithArgs;
            return frameworkelement;
        }
    }
}
