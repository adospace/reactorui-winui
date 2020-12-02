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
        PropertyValue<bool> IsTabStop { get; set; }
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
        PropertyValue<int> TabIndex { get; set; }
        PropertyValue<Transform3D> Transform3D { get; set; }
        PropertyValue<TransitionCollection> Transitions { get; set; }
        PropertyValue<bool> UseLayoutRounding { get; set; }
        PropertyValue<bool> UseSystemFocusVisuals { get; set; }
        PropertyValue<Visibility> Visibility { get; set; }
        PropertyValue<DependencyObject> XYFocusDown { get; set; }
        PropertyValue<XYFocusNavigationStrategy> XYFocusDownNavigationStrategy { get; set; }
        PropertyValue<XYFocusKeyboardNavigationMode> XYFocusKeyboardNavigation { get; set; }
        PropertyValue<DependencyObject> XYFocusLeft { get; set; }
        PropertyValue<XYFocusNavigationStrategy> XYFocusLeftNavigationStrategy { get; set; }
        PropertyValue<DependencyObject> XYFocusRight { get; set; }
        PropertyValue<XYFocusNavigationStrategy> XYFocusRightNavigationStrategy { get; set; }
        PropertyValue<DependencyObject> XYFocusUp { get; set; }
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
        PropertyValue<bool> IRxUIElement.IsTabStop { get; set; }
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
        PropertyValue<int> IRxUIElement.TabIndex { get; set; }
        PropertyValue<Transform3D> IRxUIElement.Transform3D { get; set; }
        PropertyValue<TransitionCollection> IRxUIElement.Transitions { get; set; }
        PropertyValue<bool> IRxUIElement.UseLayoutRounding { get; set; }
        PropertyValue<bool> IRxUIElement.UseSystemFocusVisuals { get; set; }
        PropertyValue<Visibility> IRxUIElement.Visibility { get; set; }
        PropertyValue<DependencyObject> IRxUIElement.XYFocusDown { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusDownNavigationStrategy { get; set; }
        PropertyValue<XYFocusKeyboardNavigationMode> IRxUIElement.XYFocusKeyboardNavigation { get; set; }
        PropertyValue<DependencyObject> IRxUIElement.XYFocusLeft { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusLeftNavigationStrategy { get; set; }
        PropertyValue<DependencyObject> IRxUIElement.XYFocusRight { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusRightNavigationStrategy { get; set; }
        PropertyValue<DependencyObject> IRxUIElement.XYFocusUp { get; set; }
        PropertyValue<XYFocusNavigationStrategy> IRxUIElement.XYFocusUpNavigationStrategy { get; set; }

        Action IRxUIElement.GotFocusAction { get; set; }
        Action<object, RoutedEventArgs> IRxUIElement.GotFocusActionWithArgs { get; set; }
        Action IRxUIElement.LostFocusAction { get; set; }
        Action<object, RoutedEventArgs> IRxUIElement.LostFocusActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxUIElement = (IRxUIElement)this;
            SetPropertyValue(NativeControl, UIElement.AccessKeyProperty, thisAsIRxUIElement.AccessKey);
            SetPropertyValue(NativeControl, UIElement.AccessKeyScopeOwnerProperty, thisAsIRxUIElement.AccessKeyScopeOwner);
            SetPropertyValue(NativeControl, UIElement.AllowDropProperty, thisAsIRxUIElement.AllowDrop);
            SetPropertyValue(NativeControl, UIElement.CacheModeProperty, thisAsIRxUIElement.CacheMode);
            SetPropertyValue(NativeControl, UIElement.CanBeScrollAnchorProperty, thisAsIRxUIElement.CanBeScrollAnchor);
            SetPropertyValue(NativeControl, UIElement.CanDragProperty, thisAsIRxUIElement.CanDrag);
            SetPropertyValue(NativeControl, UIElement.ClipProperty, thisAsIRxUIElement.Clip);
            SetPropertyValue(NativeControl, UIElement.CompositeModeProperty, thisAsIRxUIElement.CompositeMode);
            SetPropertyValue(NativeControl, UIElement.ContextFlyoutProperty, thisAsIRxUIElement.ContextFlyout);
            SetPropertyValue(NativeControl, UIElement.ExitDisplayModeOnAccessKeyInvokedProperty, thisAsIRxUIElement.ExitDisplayModeOnAccessKeyInvoked);
            SetPropertyValue(NativeControl, UIElement.HighContrastAdjustmentProperty, thisAsIRxUIElement.HighContrastAdjustment);
            SetPropertyValue(NativeControl, UIElement.IsAccessKeyScopeProperty, thisAsIRxUIElement.IsAccessKeyScope);
            SetPropertyValue(NativeControl, UIElement.IsDoubleTapEnabledProperty, thisAsIRxUIElement.IsDoubleTapEnabled);
            SetPropertyValue(NativeControl, UIElement.IsHitTestVisibleProperty, thisAsIRxUIElement.IsHitTestVisible);
            SetPropertyValue(NativeControl, UIElement.IsHoldingEnabledProperty, thisAsIRxUIElement.IsHoldingEnabled);
            SetPropertyValue(NativeControl, UIElement.IsRightTapEnabledProperty, thisAsIRxUIElement.IsRightTapEnabled);
            SetPropertyValue(NativeControl, UIElement.IsTabStopProperty, thisAsIRxUIElement.IsTabStop);
            SetPropertyValue(NativeControl, UIElement.IsTapEnabledProperty, thisAsIRxUIElement.IsTapEnabled);
            SetPropertyValue(NativeControl, UIElement.KeyboardAcceleratorPlacementModeProperty, thisAsIRxUIElement.KeyboardAcceleratorPlacementMode);
            SetPropertyValue(NativeControl, UIElement.KeyboardAcceleratorPlacementTargetProperty, thisAsIRxUIElement.KeyboardAcceleratorPlacementTarget);
            SetPropertyValue(NativeControl, UIElement.KeyTipHorizontalOffsetProperty, thisAsIRxUIElement.KeyTipHorizontalOffset);
            SetPropertyValue(NativeControl, UIElement.KeyTipPlacementModeProperty, thisAsIRxUIElement.KeyTipPlacementMode);
            SetPropertyValue(NativeControl, UIElement.KeyTipTargetProperty, thisAsIRxUIElement.KeyTipTarget);
            SetPropertyValue(NativeControl, UIElement.KeyTipVerticalOffsetProperty, thisAsIRxUIElement.KeyTipVerticalOffset);
            SetPropertyValue(NativeControl, UIElement.ManipulationModeProperty, thisAsIRxUIElement.ManipulationMode);
            SetPropertyValue(NativeControl, UIElement.OpacityProperty, thisAsIRxUIElement.Opacity);
            SetPropertyValue(NativeControl, UIElement.ProjectionProperty, thisAsIRxUIElement.Projection);
            SetPropertyValue(NativeControl, UIElement.RenderTransformProperty, thisAsIRxUIElement.RenderTransform);
            SetPropertyValue(NativeControl, UIElement.RenderTransformOriginProperty, thisAsIRxUIElement.RenderTransformOrigin);
            SetPropertyValue(NativeControl, UIElement.ShadowProperty, thisAsIRxUIElement.Shadow);
            SetPropertyValue(NativeControl, UIElement.TabFocusNavigationProperty, thisAsIRxUIElement.TabFocusNavigation);
            SetPropertyValue(NativeControl, UIElement.TabIndexProperty, thisAsIRxUIElement.TabIndex);
            SetPropertyValue(NativeControl, UIElement.Transform3DProperty, thisAsIRxUIElement.Transform3D);
            SetPropertyValue(NativeControl, UIElement.TransitionsProperty, thisAsIRxUIElement.Transitions);
            SetPropertyValue(NativeControl, UIElement.UseLayoutRoundingProperty, thisAsIRxUIElement.UseLayoutRounding);
            SetPropertyValue(NativeControl, UIElement.UseSystemFocusVisualsProperty, thisAsIRxUIElement.UseSystemFocusVisuals);
            SetPropertyValue(NativeControl, UIElement.VisibilityProperty, thisAsIRxUIElement.Visibility);
            SetPropertyValue(NativeControl, UIElement.XYFocusDownProperty, thisAsIRxUIElement.XYFocusDown);
            SetPropertyValue(NativeControl, UIElement.XYFocusDownNavigationStrategyProperty, thisAsIRxUIElement.XYFocusDownNavigationStrategy);
            SetPropertyValue(NativeControl, UIElement.XYFocusKeyboardNavigationProperty, thisAsIRxUIElement.XYFocusKeyboardNavigation);
            SetPropertyValue(NativeControl, UIElement.XYFocusLeftProperty, thisAsIRxUIElement.XYFocusLeft);
            SetPropertyValue(NativeControl, UIElement.XYFocusLeftNavigationStrategyProperty, thisAsIRxUIElement.XYFocusLeftNavigationStrategy);
            SetPropertyValue(NativeControl, UIElement.XYFocusRightProperty, thisAsIRxUIElement.XYFocusRight);
            SetPropertyValue(NativeControl, UIElement.XYFocusRightNavigationStrategyProperty, thisAsIRxUIElement.XYFocusRightNavigationStrategy);
            SetPropertyValue(NativeControl, UIElement.XYFocusUpProperty, thisAsIRxUIElement.XYFocusUp);
            SetPropertyValue(NativeControl, UIElement.XYFocusUpNavigationStrategyProperty, thisAsIRxUIElement.XYFocusUpNavigationStrategy);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

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

            OnEndAttachNativeEvents();
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
            OnBeginDetachNativeEvents();

            if (NativeControl != null)
            {
                NativeControl.GotFocus -= NativeControl_GotFocus;
                NativeControl.LostFocus -= NativeControl_LostFocus;
            }

            base.OnDetachNativeEvents();

            OnEndDetachNativeEvents();
        }

        partial void OnBeginAttachNativeEvents();
        partial void OnEndAttachNativeEvents();
        partial void OnBeginDetachNativeEvents();
        partial void OnEndDetachNativeEvents();
    }
    public static partial class RxUIElementExtensions
    {
        public static T AccessKey<T>(this T uielement, string accessKey) where T : IRxUIElement
        {
            uielement.AccessKey = new PropertyValue<string>(accessKey);
            return uielement;
        }
        public static T AccessKey<T>(this T uielement, Func<string> accessKeyFunc) where T : IRxUIElement
        {
            uielement.AccessKey = new PropertyValue<string>(accessKeyFunc);
            return uielement;
        }
        public static T AccessKeyScopeOwner<T>(this T uielement, DependencyObject accessKeyScopeOwner) where T : IRxUIElement
        {
            uielement.AccessKeyScopeOwner = new PropertyValue<DependencyObject>(accessKeyScopeOwner);
            return uielement;
        }
        public static T AccessKeyScopeOwner<T>(this T uielement, Func<DependencyObject> accessKeyScopeOwnerFunc) where T : IRxUIElement
        {
            uielement.AccessKeyScopeOwner = new PropertyValue<DependencyObject>(accessKeyScopeOwnerFunc);
            return uielement;
        }
        public static T AllowDrop<T>(this T uielement, bool allowDrop) where T : IRxUIElement
        {
            uielement.AllowDrop = new PropertyValue<bool>(allowDrop);
            return uielement;
        }
        public static T AllowDrop<T>(this T uielement, Func<bool> allowDropFunc) where T : IRxUIElement
        {
            uielement.AllowDrop = new PropertyValue<bool>(allowDropFunc);
            return uielement;
        }
        public static T CacheMode<T>(this T uielement, CacheMode cacheMode) where T : IRxUIElement
        {
            uielement.CacheMode = new PropertyValue<CacheMode>(cacheMode);
            return uielement;
        }
        public static T CacheMode<T>(this T uielement, Func<CacheMode> cacheModeFunc) where T : IRxUIElement
        {
            uielement.CacheMode = new PropertyValue<CacheMode>(cacheModeFunc);
            return uielement;
        }
        public static T CanBeScrollAnchor<T>(this T uielement, bool canBeScrollAnchor) where T : IRxUIElement
        {
            uielement.CanBeScrollAnchor = new PropertyValue<bool>(canBeScrollAnchor);
            return uielement;
        }
        public static T CanBeScrollAnchor<T>(this T uielement, Func<bool> canBeScrollAnchorFunc) where T : IRxUIElement
        {
            uielement.CanBeScrollAnchor = new PropertyValue<bool>(canBeScrollAnchorFunc);
            return uielement;
        }
        public static T CanDrag<T>(this T uielement, bool canDrag) where T : IRxUIElement
        {
            uielement.CanDrag = new PropertyValue<bool>(canDrag);
            return uielement;
        }
        public static T CanDrag<T>(this T uielement, Func<bool> canDragFunc) where T : IRxUIElement
        {
            uielement.CanDrag = new PropertyValue<bool>(canDragFunc);
            return uielement;
        }
        public static T Clip<T>(this T uielement, RectangleGeometry clip) where T : IRxUIElement
        {
            uielement.Clip = new PropertyValue<RectangleGeometry>(clip);
            return uielement;
        }
        public static T Clip<T>(this T uielement, Func<RectangleGeometry> clipFunc) where T : IRxUIElement
        {
            uielement.Clip = new PropertyValue<RectangleGeometry>(clipFunc);
            return uielement;
        }
        public static T CompositeMode<T>(this T uielement, ElementCompositeMode compositeMode) where T : IRxUIElement
        {
            uielement.CompositeMode = new PropertyValue<ElementCompositeMode>(compositeMode);
            return uielement;
        }
        public static T CompositeMode<T>(this T uielement, Func<ElementCompositeMode> compositeModeFunc) where T : IRxUIElement
        {
            uielement.CompositeMode = new PropertyValue<ElementCompositeMode>(compositeModeFunc);
            return uielement;
        }
        public static T ContextFlyout<T>(this T uielement, FlyoutBase contextFlyout) where T : IRxUIElement
        {
            uielement.ContextFlyout = new PropertyValue<FlyoutBase>(contextFlyout);
            return uielement;
        }
        public static T ContextFlyout<T>(this T uielement, Func<FlyoutBase> contextFlyoutFunc) where T : IRxUIElement
        {
            uielement.ContextFlyout = new PropertyValue<FlyoutBase>(contextFlyoutFunc);
            return uielement;
        }
        public static T ExitDisplayModeOnAccessKeyInvoked<T>(this T uielement, bool exitDisplayModeOnAccessKeyInvoked) where T : IRxUIElement
        {
            uielement.ExitDisplayModeOnAccessKeyInvoked = new PropertyValue<bool>(exitDisplayModeOnAccessKeyInvoked);
            return uielement;
        }
        public static T ExitDisplayModeOnAccessKeyInvoked<T>(this T uielement, Func<bool> exitDisplayModeOnAccessKeyInvokedFunc) where T : IRxUIElement
        {
            uielement.ExitDisplayModeOnAccessKeyInvoked = new PropertyValue<bool>(exitDisplayModeOnAccessKeyInvokedFunc);
            return uielement;
        }
        public static T HighContrastAdjustment<T>(this T uielement, ElementHighContrastAdjustment highContrastAdjustment) where T : IRxUIElement
        {
            uielement.HighContrastAdjustment = new PropertyValue<ElementHighContrastAdjustment>(highContrastAdjustment);
            return uielement;
        }
        public static T HighContrastAdjustment<T>(this T uielement, Func<ElementHighContrastAdjustment> highContrastAdjustmentFunc) where T : IRxUIElement
        {
            uielement.HighContrastAdjustment = new PropertyValue<ElementHighContrastAdjustment>(highContrastAdjustmentFunc);
            return uielement;
        }
        public static T IsAccessKeyScope<T>(this T uielement, bool isAccessKeyScope) where T : IRxUIElement
        {
            uielement.IsAccessKeyScope = new PropertyValue<bool>(isAccessKeyScope);
            return uielement;
        }
        public static T IsAccessKeyScope<T>(this T uielement, Func<bool> isAccessKeyScopeFunc) where T : IRxUIElement
        {
            uielement.IsAccessKeyScope = new PropertyValue<bool>(isAccessKeyScopeFunc);
            return uielement;
        }
        public static T IsDoubleTapEnabled<T>(this T uielement, bool isDoubleTapEnabled) where T : IRxUIElement
        {
            uielement.IsDoubleTapEnabled = new PropertyValue<bool>(isDoubleTapEnabled);
            return uielement;
        }
        public static T IsDoubleTapEnabled<T>(this T uielement, Func<bool> isDoubleTapEnabledFunc) where T : IRxUIElement
        {
            uielement.IsDoubleTapEnabled = new PropertyValue<bool>(isDoubleTapEnabledFunc);
            return uielement;
        }
        public static T IsHitTestVisible<T>(this T uielement, bool isHitTestVisible) where T : IRxUIElement
        {
            uielement.IsHitTestVisible = new PropertyValue<bool>(isHitTestVisible);
            return uielement;
        }
        public static T IsHitTestVisible<T>(this T uielement, Func<bool> isHitTestVisibleFunc) where T : IRxUIElement
        {
            uielement.IsHitTestVisible = new PropertyValue<bool>(isHitTestVisibleFunc);
            return uielement;
        }
        public static T IsHoldingEnabled<T>(this T uielement, bool isHoldingEnabled) where T : IRxUIElement
        {
            uielement.IsHoldingEnabled = new PropertyValue<bool>(isHoldingEnabled);
            return uielement;
        }
        public static T IsHoldingEnabled<T>(this T uielement, Func<bool> isHoldingEnabledFunc) where T : IRxUIElement
        {
            uielement.IsHoldingEnabled = new PropertyValue<bool>(isHoldingEnabledFunc);
            return uielement;
        }
        public static T IsRightTapEnabled<T>(this T uielement, bool isRightTapEnabled) where T : IRxUIElement
        {
            uielement.IsRightTapEnabled = new PropertyValue<bool>(isRightTapEnabled);
            return uielement;
        }
        public static T IsRightTapEnabled<T>(this T uielement, Func<bool> isRightTapEnabledFunc) where T : IRxUIElement
        {
            uielement.IsRightTapEnabled = new PropertyValue<bool>(isRightTapEnabledFunc);
            return uielement;
        }
        public static T IsTabStop<T>(this T uielement, bool isTabStop) where T : IRxUIElement
        {
            uielement.IsTabStop = new PropertyValue<bool>(isTabStop);
            return uielement;
        }
        public static T IsTabStop<T>(this T uielement, Func<bool> isTabStopFunc) where T : IRxUIElement
        {
            uielement.IsTabStop = new PropertyValue<bool>(isTabStopFunc);
            return uielement;
        }
        public static T IsTapEnabled<T>(this T uielement, bool isTapEnabled) where T : IRxUIElement
        {
            uielement.IsTapEnabled = new PropertyValue<bool>(isTapEnabled);
            return uielement;
        }
        public static T IsTapEnabled<T>(this T uielement, Func<bool> isTapEnabledFunc) where T : IRxUIElement
        {
            uielement.IsTapEnabled = new PropertyValue<bool>(isTapEnabledFunc);
            return uielement;
        }
        public static T KeyboardAcceleratorPlacementMode<T>(this T uielement, KeyboardAcceleratorPlacementMode keyboardAcceleratorPlacementMode) where T : IRxUIElement
        {
            uielement.KeyboardAcceleratorPlacementMode = new PropertyValue<KeyboardAcceleratorPlacementMode>(keyboardAcceleratorPlacementMode);
            return uielement;
        }
        public static T KeyboardAcceleratorPlacementMode<T>(this T uielement, Func<KeyboardAcceleratorPlacementMode> keyboardAcceleratorPlacementModeFunc) where T : IRxUIElement
        {
            uielement.KeyboardAcceleratorPlacementMode = new PropertyValue<KeyboardAcceleratorPlacementMode>(keyboardAcceleratorPlacementModeFunc);
            return uielement;
        }
        public static T KeyboardAcceleratorPlacementTarget<T>(this T uielement, DependencyObject keyboardAcceleratorPlacementTarget) where T : IRxUIElement
        {
            uielement.KeyboardAcceleratorPlacementTarget = new PropertyValue<DependencyObject>(keyboardAcceleratorPlacementTarget);
            return uielement;
        }
        public static T KeyboardAcceleratorPlacementTarget<T>(this T uielement, Func<DependencyObject> keyboardAcceleratorPlacementTargetFunc) where T : IRxUIElement
        {
            uielement.KeyboardAcceleratorPlacementTarget = new PropertyValue<DependencyObject>(keyboardAcceleratorPlacementTargetFunc);
            return uielement;
        }
        public static T KeyTipHorizontalOffset<T>(this T uielement, double keyTipHorizontalOffset) where T : IRxUIElement
        {
            uielement.KeyTipHorizontalOffset = new PropertyValue<double>(keyTipHorizontalOffset);
            return uielement;
        }
        public static T KeyTipHorizontalOffset<T>(this T uielement, Func<double> keyTipHorizontalOffsetFunc) where T : IRxUIElement
        {
            uielement.KeyTipHorizontalOffset = new PropertyValue<double>(keyTipHorizontalOffsetFunc);
            return uielement;
        }
        public static T KeyTipPlacementMode<T>(this T uielement, KeyTipPlacementMode keyTipPlacementMode) where T : IRxUIElement
        {
            uielement.KeyTipPlacementMode = new PropertyValue<KeyTipPlacementMode>(keyTipPlacementMode);
            return uielement;
        }
        public static T KeyTipPlacementMode<T>(this T uielement, Func<KeyTipPlacementMode> keyTipPlacementModeFunc) where T : IRxUIElement
        {
            uielement.KeyTipPlacementMode = new PropertyValue<KeyTipPlacementMode>(keyTipPlacementModeFunc);
            return uielement;
        }
        public static T KeyTipTarget<T>(this T uielement, DependencyObject keyTipTarget) where T : IRxUIElement
        {
            uielement.KeyTipTarget = new PropertyValue<DependencyObject>(keyTipTarget);
            return uielement;
        }
        public static T KeyTipTarget<T>(this T uielement, Func<DependencyObject> keyTipTargetFunc) where T : IRxUIElement
        {
            uielement.KeyTipTarget = new PropertyValue<DependencyObject>(keyTipTargetFunc);
            return uielement;
        }
        public static T KeyTipVerticalOffset<T>(this T uielement, double keyTipVerticalOffset) where T : IRxUIElement
        {
            uielement.KeyTipVerticalOffset = new PropertyValue<double>(keyTipVerticalOffset);
            return uielement;
        }
        public static T KeyTipVerticalOffset<T>(this T uielement, Func<double> keyTipVerticalOffsetFunc) where T : IRxUIElement
        {
            uielement.KeyTipVerticalOffset = new PropertyValue<double>(keyTipVerticalOffsetFunc);
            return uielement;
        }
        public static T ManipulationMode<T>(this T uielement, ManipulationModes manipulationMode) where T : IRxUIElement
        {
            uielement.ManipulationMode = new PropertyValue<ManipulationModes>(manipulationMode);
            return uielement;
        }
        public static T ManipulationMode<T>(this T uielement, Func<ManipulationModes> manipulationModeFunc) where T : IRxUIElement
        {
            uielement.ManipulationMode = new PropertyValue<ManipulationModes>(manipulationModeFunc);
            return uielement;
        }
        public static T Opacity<T>(this T uielement, double opacity) where T : IRxUIElement
        {
            uielement.Opacity = new PropertyValue<double>(opacity);
            return uielement;
        }
        public static T Opacity<T>(this T uielement, Func<double> opacityFunc) where T : IRxUIElement
        {
            uielement.Opacity = new PropertyValue<double>(opacityFunc);
            return uielement;
        }
        public static T Projection<T>(this T uielement, Projection projection) where T : IRxUIElement
        {
            uielement.Projection = new PropertyValue<Projection>(projection);
            return uielement;
        }
        public static T Projection<T>(this T uielement, Func<Projection> projectionFunc) where T : IRxUIElement
        {
            uielement.Projection = new PropertyValue<Projection>(projectionFunc);
            return uielement;
        }
        public static T RenderTransform<T>(this T uielement, Transform renderTransform) where T : IRxUIElement
        {
            uielement.RenderTransform = new PropertyValue<Transform>(renderTransform);
            return uielement;
        }
        public static T RenderTransform<T>(this T uielement, Func<Transform> renderTransformFunc) where T : IRxUIElement
        {
            uielement.RenderTransform = new PropertyValue<Transform>(renderTransformFunc);
            return uielement;
        }
        public static T RenderTransformOrigin<T>(this T uielement, Point renderTransformOrigin) where T : IRxUIElement
        {
            uielement.RenderTransformOrigin = new PropertyValue<Point>(renderTransformOrigin);
            return uielement;
        }
        public static T RenderTransformOrigin<T>(this T uielement, Func<Point> renderTransformOriginFunc) where T : IRxUIElement
        {
            uielement.RenderTransformOrigin = new PropertyValue<Point>(renderTransformOriginFunc);
            return uielement;
        }
        public static T Shadow<T>(this T uielement, Shadow shadow) where T : IRxUIElement
        {
            uielement.Shadow = new PropertyValue<Shadow>(shadow);
            return uielement;
        }
        public static T Shadow<T>(this T uielement, Func<Shadow> shadowFunc) where T : IRxUIElement
        {
            uielement.Shadow = new PropertyValue<Shadow>(shadowFunc);
            return uielement;
        }
        public static T TabFocusNavigation<T>(this T uielement, KeyboardNavigationMode tabFocusNavigation) where T : IRxUIElement
        {
            uielement.TabFocusNavigation = new PropertyValue<KeyboardNavigationMode>(tabFocusNavigation);
            return uielement;
        }
        public static T TabFocusNavigation<T>(this T uielement, Func<KeyboardNavigationMode> tabFocusNavigationFunc) where T : IRxUIElement
        {
            uielement.TabFocusNavigation = new PropertyValue<KeyboardNavigationMode>(tabFocusNavigationFunc);
            return uielement;
        }
        public static T TabIndex<T>(this T uielement, int tabIndex) where T : IRxUIElement
        {
            uielement.TabIndex = new PropertyValue<int>(tabIndex);
            return uielement;
        }
        public static T TabIndex<T>(this T uielement, Func<int> tabIndexFunc) where T : IRxUIElement
        {
            uielement.TabIndex = new PropertyValue<int>(tabIndexFunc);
            return uielement;
        }
        public static T Transform3D<T>(this T uielement, Transform3D transform3D) where T : IRxUIElement
        {
            uielement.Transform3D = new PropertyValue<Transform3D>(transform3D);
            return uielement;
        }
        public static T Transform3D<T>(this T uielement, Func<Transform3D> transform3DFunc) where T : IRxUIElement
        {
            uielement.Transform3D = new PropertyValue<Transform3D>(transform3DFunc);
            return uielement;
        }
        public static T Transitions<T>(this T uielement, TransitionCollection transitions) where T : IRxUIElement
        {
            uielement.Transitions = new PropertyValue<TransitionCollection>(transitions);
            return uielement;
        }
        public static T Transitions<T>(this T uielement, Func<TransitionCollection> transitionsFunc) where T : IRxUIElement
        {
            uielement.Transitions = new PropertyValue<TransitionCollection>(transitionsFunc);
            return uielement;
        }
        public static T UseLayoutRounding<T>(this T uielement, bool useLayoutRounding) where T : IRxUIElement
        {
            uielement.UseLayoutRounding = new PropertyValue<bool>(useLayoutRounding);
            return uielement;
        }
        public static T UseLayoutRounding<T>(this T uielement, Func<bool> useLayoutRoundingFunc) where T : IRxUIElement
        {
            uielement.UseLayoutRounding = new PropertyValue<bool>(useLayoutRoundingFunc);
            return uielement;
        }
        public static T UseSystemFocusVisuals<T>(this T uielement, bool useSystemFocusVisuals) where T : IRxUIElement
        {
            uielement.UseSystemFocusVisuals = new PropertyValue<bool>(useSystemFocusVisuals);
            return uielement;
        }
        public static T UseSystemFocusVisuals<T>(this T uielement, Func<bool> useSystemFocusVisualsFunc) where T : IRxUIElement
        {
            uielement.UseSystemFocusVisuals = new PropertyValue<bool>(useSystemFocusVisualsFunc);
            return uielement;
        }
        public static T Visibility<T>(this T uielement, Visibility visibility) where T : IRxUIElement
        {
            uielement.Visibility = new PropertyValue<Visibility>(visibility);
            return uielement;
        }
        public static T Visibility<T>(this T uielement, Func<Visibility> visibilityFunc) where T : IRxUIElement
        {
            uielement.Visibility = new PropertyValue<Visibility>(visibilityFunc);
            return uielement;
        }
        public static T XYFocusDown<T>(this T uielement, DependencyObject xYFocusDown) where T : IRxUIElement
        {
            uielement.XYFocusDown = new PropertyValue<DependencyObject>(xYFocusDown);
            return uielement;
        }
        public static T XYFocusDown<T>(this T uielement, Func<DependencyObject> xYFocusDownFunc) where T : IRxUIElement
        {
            uielement.XYFocusDown = new PropertyValue<DependencyObject>(xYFocusDownFunc);
            return uielement;
        }
        public static T XYFocusDownNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusDownNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusDownNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusDownNavigationStrategy);
            return uielement;
        }
        public static T XYFocusDownNavigationStrategy<T>(this T uielement, Func<XYFocusNavigationStrategy> xYFocusDownNavigationStrategyFunc) where T : IRxUIElement
        {
            uielement.XYFocusDownNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusDownNavigationStrategyFunc);
            return uielement;
        }
        public static T XYFocusKeyboardNavigation<T>(this T uielement, XYFocusKeyboardNavigationMode xYFocusKeyboardNavigation) where T : IRxUIElement
        {
            uielement.XYFocusKeyboardNavigation = new PropertyValue<XYFocusKeyboardNavigationMode>(xYFocusKeyboardNavigation);
            return uielement;
        }
        public static T XYFocusKeyboardNavigation<T>(this T uielement, Func<XYFocusKeyboardNavigationMode> xYFocusKeyboardNavigationFunc) where T : IRxUIElement
        {
            uielement.XYFocusKeyboardNavigation = new PropertyValue<XYFocusKeyboardNavigationMode>(xYFocusKeyboardNavigationFunc);
            return uielement;
        }
        public static T XYFocusLeft<T>(this T uielement, DependencyObject xYFocusLeft) where T : IRxUIElement
        {
            uielement.XYFocusLeft = new PropertyValue<DependencyObject>(xYFocusLeft);
            return uielement;
        }
        public static T XYFocusLeft<T>(this T uielement, Func<DependencyObject> xYFocusLeftFunc) where T : IRxUIElement
        {
            uielement.XYFocusLeft = new PropertyValue<DependencyObject>(xYFocusLeftFunc);
            return uielement;
        }
        public static T XYFocusLeftNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusLeftNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusLeftNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusLeftNavigationStrategy);
            return uielement;
        }
        public static T XYFocusLeftNavigationStrategy<T>(this T uielement, Func<XYFocusNavigationStrategy> xYFocusLeftNavigationStrategyFunc) where T : IRxUIElement
        {
            uielement.XYFocusLeftNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusLeftNavigationStrategyFunc);
            return uielement;
        }
        public static T XYFocusRight<T>(this T uielement, DependencyObject xYFocusRight) where T : IRxUIElement
        {
            uielement.XYFocusRight = new PropertyValue<DependencyObject>(xYFocusRight);
            return uielement;
        }
        public static T XYFocusRight<T>(this T uielement, Func<DependencyObject> xYFocusRightFunc) where T : IRxUIElement
        {
            uielement.XYFocusRight = new PropertyValue<DependencyObject>(xYFocusRightFunc);
            return uielement;
        }
        public static T XYFocusRightNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusRightNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusRightNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusRightNavigationStrategy);
            return uielement;
        }
        public static T XYFocusRightNavigationStrategy<T>(this T uielement, Func<XYFocusNavigationStrategy> xYFocusRightNavigationStrategyFunc) where T : IRxUIElement
        {
            uielement.XYFocusRightNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusRightNavigationStrategyFunc);
            return uielement;
        }
        public static T XYFocusUp<T>(this T uielement, DependencyObject xYFocusUp) where T : IRxUIElement
        {
            uielement.XYFocusUp = new PropertyValue<DependencyObject>(xYFocusUp);
            return uielement;
        }
        public static T XYFocusUp<T>(this T uielement, Func<DependencyObject> xYFocusUpFunc) where T : IRxUIElement
        {
            uielement.XYFocusUp = new PropertyValue<DependencyObject>(xYFocusUpFunc);
            return uielement;
        }
        public static T XYFocusUpNavigationStrategy<T>(this T uielement, XYFocusNavigationStrategy xYFocusUpNavigationStrategy) where T : IRxUIElement
        {
            uielement.XYFocusUpNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusUpNavigationStrategy);
            return uielement;
        }
        public static T XYFocusUpNavigationStrategy<T>(this T uielement, Func<XYFocusNavigationStrategy> xYFocusUpNavigationStrategyFunc) where T : IRxUIElement
        {
            uielement.XYFocusUpNavigationStrategy = new PropertyValue<XYFocusNavigationStrategy>(xYFocusUpNavigationStrategyFunc);
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
