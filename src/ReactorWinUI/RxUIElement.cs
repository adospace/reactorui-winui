using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Reflection;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Media3D;
using Windows.UI.Text;

using ReactorWinUI.Internals;

namespace ReactorWinUI
{
    public partial interface IRxUIElement : IVisualNode
    {
        PropertyValue<string> AccessKey { get; set; }
        PropertyValue<DependencyObject> AccessKeyScopeOwner { get; set; }
        PropertyValue<bool> AllowDrop { get; set; }
        PropertyValue<CacheMode> CacheMode { get; set; }
        PropertyValue<bool> CanBeScrollAnchor { get; set; }
        PropertyValue<bool> CanDrag { get; set; }
        PropertyValue<RectangleGeometry> Clip { get; set; }
        PropertyValue<ElementCompositeMode> CompositeMode { get; set; }
        PropertyValue<FlyoutBase> ContextFlyout { get; set; }
        PropertyValue<bool> ExitDisplayModeOnAccessKeyInvoked { get; set; }
        PropertyValue<ElementHighContrastAdjustment> HighContrastAdjustment { get; set; }
        PropertyValue<bool> IsAccessKeyScope { get; set; }
        PropertyValue<bool> IsDoubleTapEnabled { get; set; }
        PropertyValue<bool> IsHitTestVisible { get; set; }
        PropertyValue<bool> IsHoldingEnabled { get; set; }
        PropertyValue<bool> IsRightTapEnabled { get; set; }
        PropertyValue<bool> IsTapEnabled { get; set; }
        PropertyValue<KeyboardAcceleratorPlacementMode> KeyboardAcceleratorPlacementMode { get; set; }
        PropertyValue<DependencyObject> KeyboardAcceleratorPlacementTarget { get; set; }
        PropertyValue<double> KeyTipHorizontalOffset { get; set; }
        PropertyValue<KeyTipPlacementMode> KeyTipPlacementMode { get; set; }
        PropertyValue<DependencyObject> KeyTipTarget { get; set; }
        PropertyValue<double> KeyTipVerticalOffset { get; set; }
        PropertyValue<ManipulationModes> ManipulationMode { get; set; }
        PropertyValue<double> Opacity { get; set; }
        PropertyValue<Projection> Projection { get; set; }
        PropertyValue<Transform> RenderTransform { get; set; }
        PropertyValue<Point> RenderTransformOrigin { get; set; }
        PropertyValue<Shadow> Shadow { get; set; }
        PropertyValue<KeyboardNavigationMode> TabFocusNavigation { get; set; }
        PropertyValue<Transform3D> Transform3D { get; set; }
        PropertyValue<TransitionCollection> Transitions { get; set; }
        PropertyValue<bool> UseLayoutRounding { get; set; }
        PropertyValue<Visibility> Visibility { get; set; }
        PropertyValue<XYFocusNavigationStrategy> XYFocusDownNavigationStrategy { get; set; }
        PropertyValue<XYFocusKeyboardNavigationMode> XYFocusKeyboardNavigation { get; set; }
        PropertyValue<XYFocusNavigationStrategy> XYFocusLeftNavigationStrategy { get; set; }
        PropertyValue<XYFocusNavigationStrategy> XYFocusRightNavigationStrategy { get; set; }
        PropertyValue<XYFocusNavigationStrategy> XYFocusUpNavigationStrategy { get; set; }

        Action GotFocusAction { get; set; }
        Action<object, RoutedEventArgs> GotFocusActionWithArgs { get; set; }
        Action LostFocusAction { get; set; }
        Action<object, RoutedEventArgs> LostFocusActionWithArgs { get; set; }
    }

    public partial class RxUIElement<T> : VisualNode<T>, IRxUIElement where T : UIElement, new()
    {
        public RxUIElement()
        {

        }

        public RxUIElement(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<string> IRxUIElement.AccessKey { get; set; }
        PropertyValue<DependencyObject> IRxUIElement.AccessKeyScopeOwner { get; set; }
        PropertyValue<bool> IRxUIElement.AllowDrop { get; set; }
        PropertyValue<CacheMode> IRxUIElement.CacheMode { get; set; }
        PropertyValue<bool> IRxUIElement.CanBeScrollAnchor { get; set; }
        PropertyValue<bool> IRxUIElement.CanDrag { get; set; }
        PropertyValue<RectangleGeometry> IRxUIElement.Clip { get; set; }
        PropertyValue<ElementCompositeMode> IRxUIElement.CompositeMode { get; set; }
        PropertyValue<FlyoutBase> IRxUIElement.ContextFlyout { get; set; }
        PropertyValue<bool> IRxUIElement.ExitDisplayModeOnAccessKeyInvoked { get; set; }
        PropertyValue<ElementHighContrastAdjustment> IRxUIElement.HighContrastAdjustment { get; set; }
        PropertyValue<bool> IRxUIElement.IsAccessKeyScope { get; set; }
        PropertyValue<bool> IRxUIElement.IsDoubleTapEnabled { get; set; }
        PropertyValue<bool> IRxUIElement.IsHitTestVisible { get; set; }
        PropertyValue<bool> IRxUIElement.IsHoldingEnabled { get; set; }
        PropertyValue<bool> IRxUIElement.IsRightTapEnabled { get; set; }
        PropertyValue<bool> IRxUIElement.IsTapEnabled { get; set; }
        PropertyValue<KeyboardAcceleratorPlacementMode> IRxUIElement.KeyboardAcceleratorPlacementMode { get; set; }
        PropertyValue<DependencyObject> IRxUIElement.KeyboardAcceleratorPlacementTarget { get; set; }
        PropertyValue<double> IRxUIElement.KeyTipHorizontalOffset { get; set; }
        PropertyValue<KeyTipPlacementMode> IRxUIElement.KeyTipPlacementMode { get; set; }
        PropertyValue<DependencyObject> IRxUIElement.KeyTipTarget { get; set; }
        PropertyValue<double> IRxUIElement.KeyTipVerticalOffset { get; set; }
        PropertyValue<ManipulationModes> IRxUIElement.ManipulationMode { get; set; }
        PropertyValue<double> IRxUIElement.Opacity { get; set; }
        PropertyValue<Projection> IRxUIElement.Projection { get; set; }
        PropertyValue<Transform> IRxUIElement.RenderTransform { get; set; }
        PropertyValue<Point> IRxUIElement.RenderTransformOrigin { get; set; }
        PropertyValue<Shadow> IRxUIElement.Shadow { get; set; }
        PropertyValue<KeyboardNavigationMode> IRxUIElement.TabFocusNavigation { get; set; }
        PropertyValue<Transform3D> IRxUIElement.Transform3D { get; set; }
        PropertyValue<TransitionCollection> IRxUIElement.Transitions { get; set; }
        PropertyValue<bool> IRxUIElement.UseLayoutRounding { get; set; }
        PropertyValue<Visibility> IRxUIElement.Visibility { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusDownNavigationStrategy { get; set; }
        PropertyValue<XYFocusKeyboardNavigationMode> IRxUIElement.XYFocusKeyboardNavigation { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusLeftNavigationStrategy { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusRightNavigationStrategy { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusUpNavigationStrategy { get; set; }

        Action IRxUIElement.GotFocusAction { get; set; }
        Action<object, RoutedEventArgs> IRxUIElement.GotFocusActionWithArgs { get; set; }
        Action IRxUIElement.LostFocusAction { get; set; }
        Action<object, RoutedEventArgs> IRxUIElement.LostFocusActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxUIElement = (IRxUIElement)this;
            NativeControl.Set(this, UIElement.AccessKeyProperty, thisAsIRxUIElement.AccessKey);
            NativeControl.Set(this, UIElement.AccessKeyScopeOwnerProperty, thisAsIRxUIElement.AccessKeyScopeOwner);
            NativeControl.Set(this, UIElement.AllowDropProperty, thisAsIRxUIElement.AllowDrop);
            NativeControl.Set(this, UIElement.CacheModeProperty, thisAsIRxUIElement.CacheMode);
            NativeControl.Set(this, UIElement.CanBeScrollAnchorProperty, thisAsIRxUIElement.CanBeScrollAnchor);
            NativeControl.Set(this, UIElement.CanDragProperty, thisAsIRxUIElement.CanDrag);
            NativeControl.Set(this, UIElement.ClipProperty, thisAsIRxUIElement.Clip);
            NativeControl.Set(this, UIElement.CompositeModeProperty, thisAsIRxUIElement.CompositeMode);
            NativeControl.Set(this, UIElement.ContextFlyoutProperty, thisAsIRxUIElement.ContextFlyout);
            NativeControl.Set(this, UIElement.ExitDisplayModeOnAccessKeyInvokedProperty, thisAsIRxUIElement.ExitDisplayModeOnAccessKeyInvoked);
            NativeControl.Set(this, UIElement.HighContrastAdjustmentProperty, thisAsIRxUIElement.HighContrastAdjustment);
            NativeControl.Set(this, UIElement.IsAccessKeyScopeProperty, thisAsIRxUIElement.IsAccessKeyScope);
            NativeControl.Set(this, UIElement.IsDoubleTapEnabledProperty, thisAsIRxUIElement.IsDoubleTapEnabled);
            NativeControl.Set(this, UIElement.IsHitTestVisibleProperty, thisAsIRxUIElement.IsHitTestVisible);
            NativeControl.Set(this, UIElement.IsHoldingEnabledProperty, thisAsIRxUIElement.IsHoldingEnabled);
            NativeControl.Set(this, UIElement.IsRightTapEnabledProperty, thisAsIRxUIElement.IsRightTapEnabled);
            NativeControl.Set(this, UIElement.IsTapEnabledProperty, thisAsIRxUIElement.IsTapEnabled);
            NativeControl.Set(this, UIElement.KeyboardAcceleratorPlacementModeProperty, thisAsIRxUIElement.KeyboardAcceleratorPlacementMode);
            NativeControl.Set(this, UIElement.KeyboardAcceleratorPlacementTargetProperty, thisAsIRxUIElement.KeyboardAcceleratorPlacementTarget);
            NativeControl.Set(this, UIElement.KeyTipHorizontalOffsetProperty, thisAsIRxUIElement.KeyTipHorizontalOffset);
            NativeControl.Set(this, UIElement.KeyTipPlacementModeProperty, thisAsIRxUIElement.KeyTipPlacementMode);
            NativeControl.Set(this, UIElement.KeyTipTargetProperty, thisAsIRxUIElement.KeyTipTarget);
            NativeControl.Set(this, UIElement.KeyTipVerticalOffsetProperty, thisAsIRxUIElement.KeyTipVerticalOffset);
            NativeControl.Set(this, UIElement.ManipulationModeProperty, thisAsIRxUIElement.ManipulationMode);
            NativeControl.Set(this, UIElement.OpacityProperty, thisAsIRxUIElement.Opacity);
            NativeControl.Set(this, UIElement.ProjectionProperty, thisAsIRxUIElement.Projection);
            NativeControl.Set(this, UIElement.RenderTransformProperty, thisAsIRxUIElement.RenderTransform);
            NativeControl.Set(this, UIElement.RenderTransformOriginProperty, thisAsIRxUIElement.RenderTransformOrigin);
            NativeControl.Set(this, UIElement.ShadowProperty, thisAsIRxUIElement.Shadow);
            NativeControl.Set(this, UIElement.TabFocusNavigationProperty, thisAsIRxUIElement.TabFocusNavigation);
            NativeControl.Set(this, UIElement.Transform3DProperty, thisAsIRxUIElement.Transform3D);
            NativeControl.Set(this, UIElement.TransitionsProperty, thisAsIRxUIElement.Transitions);
            NativeControl.Set(this, UIElement.UseLayoutRoundingProperty, thisAsIRxUIElement.UseLayoutRounding);
            NativeControl.Set(this, UIElement.VisibilityProperty, thisAsIRxUIElement.Visibility);
            NativeControl.Set(this, UIElement.XYFocusDownNavigationStrategyProperty, thisAsIRxUIElement.XYFocusDownNavigationStrategy);
            NativeControl.Set(this, UIElement.XYFocusKeyboardNavigationProperty, thisAsIRxUIElement.XYFocusKeyboardNavigation);
            NativeControl.Set(this, UIElement.XYFocusLeftNavigationStrategyProperty, thisAsIRxUIElement.XYFocusLeftNavigationStrategy);
            NativeControl.Set(this, UIElement.XYFocusRightNavigationStrategyProperty, thisAsIRxUIElement.XYFocusRightNavigationStrategy);
            NativeControl.Set(this, UIElement.XYFocusUpNavigationStrategyProperty, thisAsIRxUIElement.XYFocusUpNavigationStrategy);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            if (thisAsIRxUIElement.GotFocusAction != null || thisAsIRxUIElement.GotFocusActionWithArgs != null)
            {
                NativeControl.GotFocus += NativeControl_GotFocus;
            }
            if (thisAsIRxUIElement.LostFocusAction != null || thisAsIRxUIElement.LostFocusActionWithArgs != null)
            {
                NativeControl.LostFocus += NativeControl_LostFocus;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_GotFocus(object sender, RoutedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.GotFocusAction?.Invoke();
            thisAsIRxUIElement.GotFocusActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.LostFocusAction?.Invoke();
            thisAsIRxUIElement.LostFocusActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.GotFocus -= NativeControl_GotFocus;
                NativeControl.LostFocus -= NativeControl_LostFocus;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxUIElementExtensions
    {
        public static T AccessKey<T>(this T uielement, string accessKey) where T : IRxUIElement
        {
            uielement.AccessKey = new PropertyValue<string>(accessKey);
            return uielement;
        }
        public static T AccessKeyScopeOwner<T>(this T uielement, DependencyObject accessKeyScopeOwner) where T : IRxUIElement
        {
            uielement.AccessKeyScopeOwner = new PropertyValue<DependencyObject>(accessKeyScopeOwner);
            return uielement;
        }
        public static T AllowDrop<T>(this T uielement, bool allowDrop) where T : IRxUIElement
        {
            uielement.AllowDrop = new PropertyValue<bool>(allowDrop);
            return uielement;
        }
        public static T CacheMode<T>(this T uielement, CacheMode cacheMode) where T : IRxUIElement
        {
            uielement.CacheMode = new PropertyValue<CacheMode>(cacheMode);
            return uielement;
        }
        public static T CanBeScrollAnchor<T>(this T uielement, bool canBeScrollAnchor) where T : IRxUIElement
        {
            uielement.CanBeScrollAnchor = new PropertyValue<bool>(canBeScrollAnchor);
            return uielement;
        }
        public static T CanDrag<T>(this T uielement, bool canDrag) where T : IRxUIElement
        {
            uielement.CanDrag = new PropertyValue<bool>(canDrag);
            return uielement;
        }
        public static T Clip<T>(this T uielement, RectangleGeometry clip) where T : IRxUIElement
        {
            uielement.Clip = new PropertyValue<RectangleGeometry>(clip);
            return uielement;
        }
        public static T CompositeMode<T>(this T uielement, ElementCompositeMode compositeMode) where T : IRxUIElement
        {
            uielement.CompositeMode = new PropertyValue<ElementCompositeMode>(compositeMode);
            return uielement;
        }
        public static T ContextFlyout<T>(this T uielement, FlyoutBase contextFlyout) where T : IRxUIElement
        {
            uielement.ContextFlyout = new PropertyValue<FlyoutBase>(contextFlyout);
            return uielement;
        }
        public static T ExitDisplayModeOnAccessKeyInvoked<T>(this T uielement, bool exitDisplayModeOnAccessKeyInvoked) where T : IRxUIElement
        {
            uielement.ExitDisplayModeOnAccessKeyInvoked = new PropertyValue<bool>(exitDisplayModeOnAccessKeyInvoked);
            return uielement;
        }
        public static T HighContrastAdjustment<T>(this T uielement, ElementHighContrastAdjustment highContrastAdjustment) where T : IRxUIElement
        {
            uielement.HighContrastAdjustment = new PropertyValue<ElementHighContrastAdjustment>(highContrastAdjustment);
            return uielement;
        }
        public static T IsAccessKeyScope<T>(this T uielement, bool isAccessKeyScope) where T : IRxUIElement
        {
            uielement.IsAccessKeyScope = new PropertyValue<bool>(isAccessKeyScope);
            return uielement;
        }
        public static T IsDoubleTapEnabled<T>(this T uielement, bool isDoubleTapEnabled) where T : IRxUIElement
        {
            uielement.IsDoubleTapEnabled = new PropertyValue<bool>(isDoubleTapEnabled);
            return uielement;
        }
        public static T IsHitTestVisible<T>(this T uielement, bool isHitTestVisible) where T : IRxUIElement
        {
            uielement.IsHitTestVisible = new PropertyValue<bool>(isHitTestVisible);
            return uielement;
        }
        public static T IsHoldingEnabled<T>(this T uielement, bool isHoldingEnabled) where T : IRxUIElement
        {
            uielement.IsHoldingEnabled = new PropertyValue<bool>(isHoldingEnabled);
            return uielement;
        }
        public static T IsRightTapEnabled<T>(this T uielement, bool isRightTapEnabled) where T : IRxUIElement
        {
            uielement.IsRightTapEnabled = new PropertyValue<bool>(isRightTapEnabled);
            return uielement;
        }
        public static T IsTapEnabled<T>(this T uielement, bool isTapEnabled) where T : IRxUIElement
        {
            uielement.IsTapEnabled = new PropertyValue<bool>(isTapEnabled);
            return uielement;
        }
        public static T KeyboardAcceleratorPlacementMode<T>(this T uielement, KeyboardAcceleratorPlacementMode keyboardAcceleratorPlacementMode) where T : IRxUIElement
        {
            uielement.KeyboardAcceleratorPlacementMode = new PropertyValue<KeyboardAcceleratorPlacementMode>(keyboardAcceleratorPlacementMode);
            return uielement;
        }
        public static T KeyboardAcceleratorPlacementTarget<T>(this T uielement, DependencyObject keyboardAcceleratorPlacementTarget) where T : IRxUIElement
        {
            uielement.KeyboardAcceleratorPlacementTarget = new PropertyValue<DependencyObject>(keyboardAcceleratorPlacementTarget);
            return uielement;
        }
        public static T KeyTipHorizontalOffset<T>(this T uielement, double keyTipHorizontalOffset) where T : IRxUIElement
        {
            uielement.KeyTipHorizontalOffset = new PropertyValue<double>(keyTipHorizontalOffset);
            return uielement;
        }
        public static T KeyTipPlacementMode<T>(this T uielement, KeyTipPlacementMode keyTipPlacementMode) where T : IRxUIElement
        {
            uielement.KeyTipPlacementMode = new PropertyValue<KeyTipPlacementMode>(keyTipPlacementMode);
            return uielement;
        }
        public static T KeyTipTarget<T>(this T uielement, DependencyObject keyTipTarget) where T : IRxUIElement
        {
            uielement.KeyTipTarget = new PropertyValue<DependencyObject>(keyTipTarget);
            return uielement;
        }
        public static T KeyTipVerticalOffset<T>(this T uielement, double keyTipVerticalOffset) where T : IRxUIElement
        {
            uielement.KeyTipVerticalOffset = new PropertyValue<double>(keyTipVerticalOffset);
            return uielement;
        }
        public static T ManipulationMode<T>(this T uielement, ManipulationModes manipulationMode) where T : IRxUIElement
        {
            uielement.ManipulationMode = new PropertyValue<ManipulationModes>(manipulationMode);
            return uielement;
        }
        public static T Opacity<T>(this T uielement, double opacity) where T : IRxUIElement
        {
            uielement.Opacity = new PropertyValue<double>(opacity);
            return uielement;
        }
        public static T Projection<T>(this T uielement, Projection projection) where T : IRxUIElement
        {
            uielement.Projection = new PropertyValue<Projection>(projection);
            return uielement;
        }
        public static T RenderTransform<T>(this T uielement, Transform renderTransform) where T : IRxUIElement
        {
            uielement.RenderTransform = new PropertyValue<Transform>(renderTransform);
            return uielement;
        }
        public static T RenderTransformOrigin<T>(this T uielement, Point renderTransformOrigin) where T : IRxUIElement
        {
            uielement.RenderTransformOrigin = new PropertyValue<Point>(renderTransformOrigin);
            return uielement;
        }
        public static T Shadow<T>(this T uielement, Shadow shadow) where T : IRxUIElement
        {
            uielement.Shadow = new PropertyValue<Shadow>(shadow);
            return uielement;
        }
        public static T TabFocusNavigation<T>(this T uielement, KeyboardNavigationMode tabFocusNavigation) where T : IRxUIElement
        {
            uielement.TabFocusNavigation = new PropertyValue<KeyboardNavigationMode>(tabFocusNavigation);
            return uielement;
        }
        public static T Transform3D<T>(this T uielement, Transform3D transform3D) where T : IRxUIElement
        {
            uielement.Transform3D = new PropertyValue<Transform3D>(transform3D);
            return uielement;
        }
        public static T Transitions<T>(this T uielement, TransitionCollection transitions) where T : IRxUIElement
        {
            uielement.Transitions = new PropertyValue<TransitionCollection>(transitions);
            return uielement;
        }
        public static T UseLayoutRounding<T>(this T uielement, bool useLayoutRounding) where T : IRxUIElement
        {
            uielement.UseLayoutRounding = new PropertyValue<bool>(useLayoutRounding);
            return uielement;
        }
        public static T Visibility<T>(this T uielement, Visibility visibility) where T : IRxUIElement
        {
            uielement.Visibility = new PropertyValue<Visibility>(visibility);
            return uielement;
        }
        public static T XYFocusDownNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusDownNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusDownNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusDownNavigationStrategy);
            return uielement;
        }
        public static T XYFocusKeyboardNavigation<T>(this T uielement, XYFocusKeyboardNavigationMode xYFocusKeyboardNavigation) where T : IRxUIElement
        {
            uielement.XYFocusKeyboardNavigation = new PropertyValue<XYFocusKeyboardNavigationMode>(xYFocusKeyboardNavigation);
            return uielement;
        }
        public static T XYFocusLeftNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusLeftNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusLeftNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusLeftNavigationStrategy);
            return uielement;
        }
        public static T XYFocusRightNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusRightNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusRightNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusRightNavigationStrategy);
            return uielement;
        }
        public static T XYFocusUpNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusUpNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusUpNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusUpNavigationStrategy);
            return uielement;
        }
        public static T OnGotFocus<T>(this T uielement, Action gotfocusAction) where T : IRxUIElement
        {
            uielement.GotFocusAction = gotfocusAction;
            return uielement;
        }

        public static T OnGotFocus<T>(this T uielement, Action<object, RoutedEventArgs> gotfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.GotFocusActionWithArgs = gotfocusActionWithArgs;
            return uielement;
        }
        public static T OnLostFocus<T>(this T uielement, Action lostfocusAction) where T : IRxUIElement
        {
            uielement.LostFocusAction = lostfocusAction;
            return uielement;
        }

        public static T OnLostFocus<T>(this T uielement, Action<object, RoutedEventArgs> lostfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.LostFocusActionWithArgs = lostfocusActionWithArgs;
            return uielement;
        }
    }
}
