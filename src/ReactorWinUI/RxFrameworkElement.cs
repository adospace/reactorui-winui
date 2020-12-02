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
            SetPropertyValue(NativeControl, FrameworkElement.AllowFocusOnInteractionProperty, thisAsIRxFrameworkElement.AllowFocusOnInteraction);
            SetPropertyValue(NativeControl, FrameworkElement.AllowFocusWhenDisabledProperty, thisAsIRxFrameworkElement.AllowFocusWhenDisabled);
            SetPropertyValue(NativeControl, FrameworkElement.DataContextProperty, thisAsIRxFrameworkElement.DataContext);
            SetPropertyValue(NativeControl, FrameworkElement.FlowDirectionProperty, thisAsIRxFrameworkElement.FlowDirection);
            SetPropertyValue(NativeControl, FrameworkElement.FocusVisualMarginProperty, thisAsIRxFrameworkElement.FocusVisualMargin);
            SetPropertyValue(NativeControl, FrameworkElement.FocusVisualPrimaryBrushProperty, thisAsIRxFrameworkElement.FocusVisualPrimaryBrush);
            SetPropertyValue(NativeControl, FrameworkElement.FocusVisualPrimaryThicknessProperty, thisAsIRxFrameworkElement.FocusVisualPrimaryThickness);
            SetPropertyValue(NativeControl, FrameworkElement.FocusVisualSecondaryBrushProperty, thisAsIRxFrameworkElement.FocusVisualSecondaryBrush);
            SetPropertyValue(NativeControl, FrameworkElement.FocusVisualSecondaryThicknessProperty, thisAsIRxFrameworkElement.FocusVisualSecondaryThickness);
            SetPropertyValue(NativeControl, FrameworkElement.HeightProperty, thisAsIRxFrameworkElement.Height);
            SetPropertyValue(NativeControl, FrameworkElement.HorizontalAlignmentProperty, thisAsIRxFrameworkElement.HorizontalAlignment);
            SetPropertyValue(NativeControl, FrameworkElement.LanguageProperty, thisAsIRxFrameworkElement.Language);
            SetPropertyValue(NativeControl, FrameworkElement.MarginProperty, thisAsIRxFrameworkElement.Margin);
            SetPropertyValue(NativeControl, FrameworkElement.MaxHeightProperty, thisAsIRxFrameworkElement.MaxHeight);
            SetPropertyValue(NativeControl, FrameworkElement.MaxWidthProperty, thisAsIRxFrameworkElement.MaxWidth);
            SetPropertyValue(NativeControl, FrameworkElement.MinHeightProperty, thisAsIRxFrameworkElement.MinHeight);
            SetPropertyValue(NativeControl, FrameworkElement.MinWidthProperty, thisAsIRxFrameworkElement.MinWidth);
            SetPropertyValue(NativeControl, FrameworkElement.NameProperty, thisAsIRxFrameworkElement.Name);
            SetPropertyValue(NativeControl, FrameworkElement.RequestedThemeProperty, thisAsIRxFrameworkElement.RequestedTheme);
            SetPropertyValue(NativeControl, FrameworkElement.StyleProperty, thisAsIRxFrameworkElement.Style);
            SetPropertyValue(NativeControl, FrameworkElement.TagProperty, thisAsIRxFrameworkElement.Tag);
            SetPropertyValue(NativeControl, FrameworkElement.VerticalAlignmentProperty, thisAsIRxFrameworkElement.VerticalAlignment);
            SetPropertyValue(NativeControl, FrameworkElement.WidthProperty, thisAsIRxFrameworkElement.Width);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

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

            OnEndAttachNativeEvents();
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
            OnBeginDetachNativeEvents();

            if (NativeControl != null)
            {
                NativeControl.Loaded -= NativeControl_Loaded;
                NativeControl.Unloaded -= NativeControl_Unloaded;
            }

            base.OnDetachNativeEvents();

            OnEndDetachNativeEvents();
        }

        partial void OnBeginAttachNativeEvents();
        partial void OnEndAttachNativeEvents();
        partial void OnBeginDetachNativeEvents();
        partial void OnEndDetachNativeEvents();
    }
    public static partial class RxFrameworkElementExtensions
    {
        public static T AllowFocusOnInteraction<T>(this T frameworkelement, bool allowFocusOnInteraction) where T : IRxFrameworkElement
        {
            frameworkelement.AllowFocusOnInteraction = new PropertyValue<bool>(allowFocusOnInteraction);
            return frameworkelement;
        }
        public static T AllowFocusOnInteraction<T>(this T frameworkelement, Func<bool> allowFocusOnInteractionFunc) where T : IRxFrameworkElement
        {
            frameworkelement.AllowFocusOnInteraction = new PropertyValue<bool>(allowFocusOnInteractionFunc);
            return frameworkelement;
        }
        public static T AllowFocusWhenDisabled<T>(this T frameworkelement, bool allowFocusWhenDisabled) where T : IRxFrameworkElement
        {
            frameworkelement.AllowFocusWhenDisabled = new PropertyValue<bool>(allowFocusWhenDisabled);
            return frameworkelement;
        }
        public static T AllowFocusWhenDisabled<T>(this T frameworkelement, Func<bool> allowFocusWhenDisabledFunc) where T : IRxFrameworkElement
        {
            frameworkelement.AllowFocusWhenDisabled = new PropertyValue<bool>(allowFocusWhenDisabledFunc);
            return frameworkelement;
        }
        public static T DataContext<T>(this T frameworkelement, object dataContext) where T : IRxFrameworkElement
        {
            frameworkelement.DataContext = new PropertyValue<object>(dataContext);
            return frameworkelement;
        }
        public static T DataContext<T>(this T frameworkelement, Func<object> dataContextFunc) where T : IRxFrameworkElement
        {
            frameworkelement.DataContext = new PropertyValue<object>(dataContextFunc);
            return frameworkelement;
        }
        public static T FlowDirection<T>(this T frameworkelement, FlowDirection flowDirection) where T : IRxFrameworkElement
        {
            frameworkelement.FlowDirection = new PropertyValue<FlowDirection>(flowDirection);
            return frameworkelement;
        }
        public static T FlowDirection<T>(this T frameworkelement, Func<FlowDirection> flowDirectionFunc) where T : IRxFrameworkElement
        {
            frameworkelement.FlowDirection = new PropertyValue<FlowDirection>(flowDirectionFunc);
            return frameworkelement;
        }
        public static T FocusVisualMargin<T>(this T frameworkelement, Thickness focusVisualMargin) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualMargin = new PropertyValue<Thickness>(focusVisualMargin);
            return frameworkelement;
        }
        public static T FocusVisualMargin<T>(this T frameworkelement, Func<Thickness> focusVisualMarginFunc) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualMargin = new PropertyValue<Thickness>(focusVisualMarginFunc);
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
        public static T FocusVisualPrimaryBrush<T>(this T frameworkelement, Func<Brush> focusVisualPrimaryBrushFunc) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualPrimaryBrush = new PropertyValue<Brush>(focusVisualPrimaryBrushFunc);
            return frameworkelement;
        }
        public static T FocusVisualPrimaryThickness<T>(this T frameworkelement, Thickness focusVisualPrimaryThickness) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualPrimaryThickness = new PropertyValue<Thickness>(focusVisualPrimaryThickness);
            return frameworkelement;
        }
        public static T FocusVisualPrimaryThickness<T>(this T frameworkelement, Func<Thickness> focusVisualPrimaryThicknessFunc) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualPrimaryThickness = new PropertyValue<Thickness>(focusVisualPrimaryThicknessFunc);
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
        public static T FocusVisualSecondaryBrush<T>(this T frameworkelement, Func<Brush> focusVisualSecondaryBrushFunc) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualSecondaryBrush = new PropertyValue<Brush>(focusVisualSecondaryBrushFunc);
            return frameworkelement;
        }
        public static T FocusVisualSecondaryThickness<T>(this T frameworkelement, Thickness focusVisualSecondaryThickness) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualSecondaryThickness = new PropertyValue<Thickness>(focusVisualSecondaryThickness);
            return frameworkelement;
        }
        public static T FocusVisualSecondaryThickness<T>(this T frameworkelement, Func<Thickness> focusVisualSecondaryThicknessFunc) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualSecondaryThickness = new PropertyValue<Thickness>(focusVisualSecondaryThicknessFunc);
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
        public static T Height<T>(this T frameworkelement, Func<double> heightFunc) where T : IRxFrameworkElement
        {
            frameworkelement.Height = new PropertyValue<double>(heightFunc);
            return frameworkelement;
        }
        public static T HorizontalAlignment<T>(this T frameworkelement, HorizontalAlignment horizontalAlignment) where T : IRxFrameworkElement
        {
            frameworkelement.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(horizontalAlignment);
            return frameworkelement;
        }
        public static T HorizontalAlignment<T>(this T frameworkelement, Func<HorizontalAlignment> horizontalAlignmentFunc) where T : IRxFrameworkElement
        {
            frameworkelement.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(horizontalAlignmentFunc);
            return frameworkelement;
        }
        public static T Language<T>(this T frameworkelement, string language) where T : IRxFrameworkElement
        {
            frameworkelement.Language = new PropertyValue<string>(language);
            return frameworkelement;
        }
        public static T Language<T>(this T frameworkelement, Func<string> languageFunc) where T : IRxFrameworkElement
        {
            frameworkelement.Language = new PropertyValue<string>(languageFunc);
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, Thickness margin) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(margin);
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, Func<Thickness> marginFunc) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(marginFunc);
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
        public static T MaxHeight<T>(this T frameworkelement, Func<double> maxHeightFunc) where T : IRxFrameworkElement
        {
            frameworkelement.MaxHeight = new PropertyValue<double>(maxHeightFunc);
            return frameworkelement;
        }
        public static T MaxWidth<T>(this T frameworkelement, double maxWidth) where T : IRxFrameworkElement
        {
            frameworkelement.MaxWidth = new PropertyValue<double>(maxWidth);
            return frameworkelement;
        }
        public static T MaxWidth<T>(this T frameworkelement, Func<double> maxWidthFunc) where T : IRxFrameworkElement
        {
            frameworkelement.MaxWidth = new PropertyValue<double>(maxWidthFunc);
            return frameworkelement;
        }
        public static T MinHeight<T>(this T frameworkelement, double minHeight) where T : IRxFrameworkElement
        {
            frameworkelement.MinHeight = new PropertyValue<double>(minHeight);
            return frameworkelement;
        }
        public static T MinHeight<T>(this T frameworkelement, Func<double> minHeightFunc) where T : IRxFrameworkElement
        {
            frameworkelement.MinHeight = new PropertyValue<double>(minHeightFunc);
            return frameworkelement;
        }
        public static T MinWidth<T>(this T frameworkelement, double minWidth) where T : IRxFrameworkElement
        {
            frameworkelement.MinWidth = new PropertyValue<double>(minWidth);
            return frameworkelement;
        }
        public static T MinWidth<T>(this T frameworkelement, Func<double> minWidthFunc) where T : IRxFrameworkElement
        {
            frameworkelement.MinWidth = new PropertyValue<double>(minWidthFunc);
            return frameworkelement;
        }
        public static T Name<T>(this T frameworkelement, string name) where T : IRxFrameworkElement
        {
            frameworkelement.Name = new PropertyValue<string>(name);
            return frameworkelement;
        }
        public static T Name<T>(this T frameworkelement, Func<string> nameFunc) where T : IRxFrameworkElement
        {
            frameworkelement.Name = new PropertyValue<string>(nameFunc);
            return frameworkelement;
        }
        public static T RequestedTheme<T>(this T frameworkelement, ElementTheme requestedTheme) where T : IRxFrameworkElement
        {
            frameworkelement.RequestedTheme = new PropertyValue<ElementTheme>(requestedTheme);
            return frameworkelement;
        }
        public static T RequestedTheme<T>(this T frameworkelement, Func<ElementTheme> requestedThemeFunc) where T : IRxFrameworkElement
        {
            frameworkelement.RequestedTheme = new PropertyValue<ElementTheme>(requestedThemeFunc);
            return frameworkelement;
        }
        public static T Style<T>(this T frameworkelement, Style style) where T : IRxFrameworkElement
        {
            frameworkelement.Style = new PropertyValue<Style>(style);
            return frameworkelement;
        }
        public static T Style<T>(this T frameworkelement, Func<Style> styleFunc) where T : IRxFrameworkElement
        {
            frameworkelement.Style = new PropertyValue<Style>(styleFunc);
            return frameworkelement;
        }
        public static T Tag<T>(this T frameworkelement, object tag) where T : IRxFrameworkElement
        {
            frameworkelement.Tag = new PropertyValue<object>(tag);
            return frameworkelement;
        }
        public static T Tag<T>(this T frameworkelement, Func<object> tagFunc) where T : IRxFrameworkElement
        {
            frameworkelement.Tag = new PropertyValue<object>(tagFunc);
            return frameworkelement;
        }
        public static T VerticalAlignment<T>(this T frameworkelement, VerticalAlignment verticalAlignment) where T : IRxFrameworkElement
        {
            frameworkelement.VerticalAlignment = new PropertyValue<VerticalAlignment>(verticalAlignment);
            return frameworkelement;
        }
        public static T VerticalAlignment<T>(this T frameworkelement, Func<VerticalAlignment> verticalAlignmentFunc) where T : IRxFrameworkElement
        {
            frameworkelement.VerticalAlignment = new PropertyValue<VerticalAlignment>(verticalAlignmentFunc);
            return frameworkelement;
        }
        public static T Width<T>(this T frameworkelement, double width) where T : IRxFrameworkElement
        {
            frameworkelement.Width = new PropertyValue<double>(width);
            return frameworkelement;
        }
        public static T Width<T>(this T frameworkelement, Func<double> widthFunc) where T : IRxFrameworkElement
        {
            frameworkelement.Width = new PropertyValue<double>(widthFunc);
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
