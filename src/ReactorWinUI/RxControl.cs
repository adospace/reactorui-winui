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
    public partial interface IRxControl : IRxFrameworkElement
    {
        PropertyValue<Brush> Background { get; set; }
        PropertyValue<BackgroundSizing> BackgroundSizing { get; set; }
        PropertyValue<Brush> BorderBrush { get; set; }
        PropertyValue<Thickness> BorderThickness { get; set; }
        PropertyValue<int> CharacterSpacing { get; set; }
        PropertyValue<CornerRadius> CornerRadius { get; set; }
        PropertyValue<Uri> DefaultStyleResourceUri { get; set; }
        PropertyValue<ElementSoundMode> ElementSoundMode { get; set; }
        PropertyValue<FontFamily> FontFamily { get; set; }
        PropertyValue<double> FontSize { get; set; }
        PropertyValue<FontStretch> FontStretch { get; set; }
        PropertyValue<FontStyle> FontStyle { get; set; }
        PropertyValue<FontWeight> FontWeight { get; set; }
        PropertyValue<Brush> Foreground { get; set; }
        PropertyValue<HorizontalAlignment> HorizontalContentAlignment { get; set; }
        PropertyValue<bool> IsEnabled { get; set; }
        PropertyValue<bool> IsFocusEngaged { get; set; }
        PropertyValue<bool> IsFocusEngagementEnabled { get; set; }
        PropertyValue<bool> IsTabStop { get; set; }
        PropertyValue<bool> IsTextScaleFactorEnabled { get; set; }
        PropertyValue<Thickness> Padding { get; set; }
        PropertyValue<RequiresPointer> RequiresPointer { get; set; }
        PropertyValue<int> TabIndex { get; set; }
        PropertyValue<KeyboardNavigationMode> TabNavigation { get; set; }
        PropertyValue<bool> UseSystemFocusVisuals { get; set; }
        PropertyValue<VerticalAlignment> VerticalContentAlignment { get; set; }
        PropertyValue<DependencyObject> XYFocusDown { get; set; }
        PropertyValue<DependencyObject> XYFocusLeft { get; set; }
        PropertyValue<DependencyObject> XYFocusRight { get; set; }
        PropertyValue<DependencyObject> XYFocusUp { get; set; }

    }

    public partial class RxControl<T> : RxFrameworkElement<T>, IRxControl where T : Control, new()
    {
        public RxControl()
        {

        }

        public RxControl(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<Brush> IRxControl.Background { get; set; }
        PropertyValue<BackgroundSizing> IRxControl.BackgroundSizing { get; set; }
        PropertyValue<Brush> IRxControl.BorderBrush { get; set; }
        PropertyValue<Thickness> IRxControl.BorderThickness { get; set; }
        PropertyValue<int> IRxControl.CharacterSpacing { get; set; }
        PropertyValue<CornerRadius> IRxControl.CornerRadius { get; set; }
        PropertyValue<Uri> IRxControl.DefaultStyleResourceUri { get; set; }
        PropertyValue<ElementSoundMode> IRxControl.ElementSoundMode { get; set; }
        PropertyValue<FontFamily> IRxControl.FontFamily { get; set; }
        PropertyValue<double> IRxControl.FontSize { get; set; }
        PropertyValue<FontStretch> IRxControl.FontStretch { get; set; }
        PropertyValue<FontStyle> IRxControl.FontStyle { get; set; }
        PropertyValue<FontWeight> IRxControl.FontWeight { get; set; }
        PropertyValue<Brush> IRxControl.Foreground { get; set; }
        PropertyValue<HorizontalAlignment> IRxControl.HorizontalContentAlignment { get; set; }
        PropertyValue<bool> IRxControl.IsEnabled { get; set; }
        PropertyValue<bool> IRxControl.IsFocusEngaged { get; set; }
        PropertyValue<bool> IRxControl.IsFocusEngagementEnabled { get; set; }
        PropertyValue<bool> IRxControl.IsTabStop { get; set; }
        PropertyValue<bool> IRxControl.IsTextScaleFactorEnabled { get; set; }
        PropertyValue<Thickness> IRxControl.Padding { get; set; }
        PropertyValue<RequiresPointer> IRxControl.RequiresPointer { get; set; }
        PropertyValue<int> IRxControl.TabIndex { get; set; }
        PropertyValue<KeyboardNavigationMode> IRxControl.TabNavigation { get; set; }
        PropertyValue<bool> IRxControl.UseSystemFocusVisuals { get; set; }
        PropertyValue<VerticalAlignment> IRxControl.VerticalContentAlignment { get; set; }
        PropertyValue<DependencyObject> IRxControl.XYFocusDown { get; set; }
        PropertyValue<DependencyObject> IRxControl.XYFocusLeft { get; set; }
        PropertyValue<DependencyObject> IRxControl.XYFocusRight { get; set; }
        PropertyValue<DependencyObject> IRxControl.XYFocusUp { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxControl = (IRxControl)this;
            NativeControl.Set(this, Control.BackgroundProperty, thisAsIRxControl.Background);
            NativeControl.Set(this, Control.BackgroundSizingProperty, thisAsIRxControl.BackgroundSizing);
            NativeControl.Set(this, Control.BorderBrushProperty, thisAsIRxControl.BorderBrush);
            NativeControl.Set(this, Control.BorderThicknessProperty, thisAsIRxControl.BorderThickness);
            NativeControl.Set(this, Control.CharacterSpacingProperty, thisAsIRxControl.CharacterSpacing);
            NativeControl.Set(this, Control.CornerRadiusProperty, thisAsIRxControl.CornerRadius);
            NativeControl.Set(this, Control.DefaultStyleResourceUriProperty, thisAsIRxControl.DefaultStyleResourceUri);
            NativeControl.Set(this, Control.ElementSoundModeProperty, thisAsIRxControl.ElementSoundMode);
            NativeControl.Set(this, Control.FontFamilyProperty, thisAsIRxControl.FontFamily);
            NativeControl.Set(this, Control.FontSizeProperty, thisAsIRxControl.FontSize);
            NativeControl.Set(this, Control.FontStretchProperty, thisAsIRxControl.FontStretch);
            NativeControl.Set(this, Control.FontStyleProperty, thisAsIRxControl.FontStyle);
            NativeControl.Set(this, Control.FontWeightProperty, thisAsIRxControl.FontWeight);
            NativeControl.Set(this, Control.ForegroundProperty, thisAsIRxControl.Foreground);
            NativeControl.Set(this, Control.HorizontalContentAlignmentProperty, thisAsIRxControl.HorizontalContentAlignment);
            NativeControl.Set(this, Control.IsEnabledProperty, thisAsIRxControl.IsEnabled);
            NativeControl.Set(this, Control.IsFocusEngagedProperty, thisAsIRxControl.IsFocusEngaged);
            NativeControl.Set(this, Control.IsFocusEngagementEnabledProperty, thisAsIRxControl.IsFocusEngagementEnabled);
            NativeControl.Set(this, Control.IsTabStopProperty, thisAsIRxControl.IsTabStop);
            NativeControl.Set(this, Control.IsTextScaleFactorEnabledProperty, thisAsIRxControl.IsTextScaleFactorEnabled);
            NativeControl.Set(this, Control.PaddingProperty, thisAsIRxControl.Padding);
            NativeControl.Set(this, Control.RequiresPointerProperty, thisAsIRxControl.RequiresPointer);
            NativeControl.Set(this, Control.TabIndexProperty, thisAsIRxControl.TabIndex);
            NativeControl.Set(this, Control.TabNavigationProperty, thisAsIRxControl.TabNavigation);
            NativeControl.Set(this, Control.UseSystemFocusVisualsProperty, thisAsIRxControl.UseSystemFocusVisuals);
            NativeControl.Set(this, Control.VerticalContentAlignmentProperty, thisAsIRxControl.VerticalContentAlignment);
            NativeControl.Set(this, Control.XYFocusDownProperty, thisAsIRxControl.XYFocusDown);
            NativeControl.Set(this, Control.XYFocusLeftProperty, thisAsIRxControl.XYFocusLeft);
            NativeControl.Set(this, Control.XYFocusRightProperty, thisAsIRxControl.XYFocusRight);
            NativeControl.Set(this, Control.XYFocusUpProperty, thisAsIRxControl.XYFocusUp);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxControl = (IRxControl)this;

            base.OnAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxControlExtensions
    {
        public static T Background<T>(this T control, Brush background) where T : IRxControl
        {
            control.Background = new PropertyValue<Brush>(background);
            return control;
        }
        public static T BackgroundSizing<T>(this T control, BackgroundSizing backgroundSizing) where T : IRxControl
        {
            control.BackgroundSizing = new PropertyValue<BackgroundSizing>(backgroundSizing);
            return control;
        }
        public static T BorderBrush<T>(this T control, Brush borderBrush) where T : IRxControl
        {
            control.BorderBrush = new PropertyValue<Brush>(borderBrush);
            return control;
        }
        public static T BorderThickness<T>(this T control, Thickness borderThickness) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(borderThickness);
            return control;
        }
        public static T BorderThickness<T>(this T control, double leftRight, double topBottom) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return control;
        }
        public static T BorderThickness<T>(this T control, double uniformSize) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return control;
        }
        public static T CharacterSpacing<T>(this T control, int characterSpacing) where T : IRxControl
        {
            control.CharacterSpacing = new PropertyValue<int>(characterSpacing);
            return control;
        }
        public static T CornerRadius<T>(this T control, CornerRadius cornerRadius) where T : IRxControl
        {
            control.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return control;
        }
        public static T DefaultStyleResourceUri<T>(this T control, Uri defaultStyleResourceUri) where T : IRxControl
        {
            control.DefaultStyleResourceUri = new PropertyValue<Uri>(defaultStyleResourceUri);
            return control;
        }
        public static T ElementSoundMode<T>(this T control, ElementSoundMode elementSoundMode) where T : IRxControl
        {
            control.ElementSoundMode = new PropertyValue<ElementSoundMode>(elementSoundMode);
            return control;
        }
        public static T FontFamily<T>(this T control, FontFamily fontFamily) where T : IRxControl
        {
            control.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return control;
        }
        public static T FontSize<T>(this T control, double fontSize) where T : IRxControl
        {
            control.FontSize = new PropertyValue<double>(fontSize);
            return control;
        }
        public static T FontStretch<T>(this T control, FontStretch fontStretch) where T : IRxControl
        {
            control.FontStretch = new PropertyValue<FontStretch>(fontStretch);
            return control;
        }
        public static T FontStyle<T>(this T control, FontStyle fontStyle) where T : IRxControl
        {
            control.FontStyle = new PropertyValue<FontStyle>(fontStyle);
            return control;
        }
        public static T FontWeight<T>(this T control, FontWeight fontWeight) where T : IRxControl
        {
            control.FontWeight = new PropertyValue<FontWeight>(fontWeight);
            return control;
        }
        public static T Foreground<T>(this T control, Brush foreground) where T : IRxControl
        {
            control.Foreground = new PropertyValue<Brush>(foreground);
            return control;
        }
        public static T HorizontalContentAlignment<T>(this T control, HorizontalAlignment horizontalContentAlignment) where T : IRxControl
        {
            control.HorizontalContentAlignment = new PropertyValue<HorizontalAlignment>(horizontalContentAlignment);
            return control;
        }
        public static T IsEnabled<T>(this T control, bool isEnabled) where T : IRxControl
        {
            control.IsEnabled = new PropertyValue<bool>(isEnabled);
            return control;
        }
        public static T IsFocusEngaged<T>(this T control, bool isFocusEngaged) where T : IRxControl
        {
            control.IsFocusEngaged = new PropertyValue<bool>(isFocusEngaged);
            return control;
        }
        public static T IsFocusEngagementEnabled<T>(this T control, bool isFocusEngagementEnabled) where T : IRxControl
        {
            control.IsFocusEngagementEnabled = new PropertyValue<bool>(isFocusEngagementEnabled);
            return control;
        }
        public static T IsTabStop<T>(this T control, bool isTabStop) where T : IRxControl
        {
            control.IsTabStop = new PropertyValue<bool>(isTabStop);
            return control;
        }
        public static T IsTextScaleFactorEnabled<T>(this T control, bool isTextScaleFactorEnabled) where T : IRxControl
        {
            control.IsTextScaleFactorEnabled = new PropertyValue<bool>(isTextScaleFactorEnabled);
            return control;
        }
        public static T Padding<T>(this T control, Thickness padding) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(padding);
            return control;
        }
        public static T Padding<T>(this T control, double leftRight, double topBottom) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return control;
        }
        public static T Padding<T>(this T control, double uniformSize) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return control;
        }
        public static T RequiresPointer<T>(this T control, RequiresPointer requiresPointer) where T : IRxControl
        {
            control.RequiresPointer = new PropertyValue<RequiresPointer>(requiresPointer);
            return control;
        }
        public static T TabIndex<T>(this T control, int tabIndex) where T : IRxControl
        {
            control.TabIndex = new PropertyValue<int>(tabIndex);
            return control;
        }
        public static T TabNavigation<T>(this T control, KeyboardNavigationMode tabNavigation) where T : IRxControl
        {
            control.TabNavigation = new PropertyValue<KeyboardNavigationMode>(tabNavigation);
            return control;
        }
        public static T UseSystemFocusVisuals<T>(this T control, bool useSystemFocusVisuals) where T : IRxControl
        {
            control.UseSystemFocusVisuals = new PropertyValue<bool>(useSystemFocusVisuals);
            return control;
        }
        public static T VerticalContentAlignment<T>(this T control, VerticalAlignment verticalContentAlignment) where T : IRxControl
        {
            control.VerticalContentAlignment = new PropertyValue<VerticalAlignment>(verticalContentAlignment);
            return control;
        }
        public static T XYFocusDown<T>(this T control, DependencyObject xYFocusDown) where T : IRxControl
        {
            control.XYFocusDown = new PropertyValue<DependencyObject>(xYFocusDown);
            return control;
        }
        public static T XYFocusLeft<T>(this T control, DependencyObject xYFocusLeft) where T : IRxControl
        {
            control.XYFocusLeft = new PropertyValue<DependencyObject>(xYFocusLeft);
            return control;
        }
        public static T XYFocusRight<T>(this T control, DependencyObject xYFocusRight) where T : IRxControl
        {
            control.XYFocusRight = new PropertyValue<DependencyObject>(xYFocusRight);
            return control;
        }
        public static T XYFocusUp<T>(this T control, DependencyObject xYFocusUp) where T : IRxControl
        {
            control.XYFocusUp = new PropertyValue<DependencyObject>(xYFocusUp);
            return control;
        }
    }
}
