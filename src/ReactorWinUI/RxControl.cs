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
        PropertyValue<bool> IsTextScaleFactorEnabled { get; set; }
        PropertyValue<Thickness> Padding { get; set; }
        PropertyValue<RequiresPointer> RequiresPointer { get; set; }
        PropertyValue<KeyboardNavigationMode> TabNavigation { get; set; }
        PropertyValue<VerticalAlignment> VerticalContentAlignment { get; set; }

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
        PropertyValue<bool> IRxControl.IsTextScaleFactorEnabled { get; set; }
        PropertyValue<Thickness> IRxControl.Padding { get; set; }
        PropertyValue<RequiresPointer> IRxControl.RequiresPointer { get; set; }
        PropertyValue<KeyboardNavigationMode> IRxControl.TabNavigation { get; set; }
        PropertyValue<VerticalAlignment> IRxControl.VerticalContentAlignment { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxControl = (IRxControl)this;
            SetPropertyValue(NativeControl, Control.BackgroundProperty, thisAsIRxControl.Background);
            SetPropertyValue(NativeControl, Control.BackgroundSizingProperty, thisAsIRxControl.BackgroundSizing);
            SetPropertyValue(NativeControl, Control.BorderBrushProperty, thisAsIRxControl.BorderBrush);
            SetPropertyValue(NativeControl, Control.BorderThicknessProperty, thisAsIRxControl.BorderThickness);
            SetPropertyValue(NativeControl, Control.CharacterSpacingProperty, thisAsIRxControl.CharacterSpacing);
            SetPropertyValue(NativeControl, Control.CornerRadiusProperty, thisAsIRxControl.CornerRadius);
            SetPropertyValue(NativeControl, Control.DefaultStyleResourceUriProperty, thisAsIRxControl.DefaultStyleResourceUri);
            SetPropertyValue(NativeControl, Control.ElementSoundModeProperty, thisAsIRxControl.ElementSoundMode);
            SetPropertyValue(NativeControl, Control.FontFamilyProperty, thisAsIRxControl.FontFamily);
            SetPropertyValue(NativeControl, Control.FontSizeProperty, thisAsIRxControl.FontSize);
            SetPropertyValue(NativeControl, Control.FontStretchProperty, thisAsIRxControl.FontStretch);
            SetPropertyValue(NativeControl, Control.FontStyleProperty, thisAsIRxControl.FontStyle);
            SetPropertyValue(NativeControl, Control.FontWeightProperty, thisAsIRxControl.FontWeight);
            SetPropertyValue(NativeControl, Control.ForegroundProperty, thisAsIRxControl.Foreground);
            SetPropertyValue(NativeControl, Control.HorizontalContentAlignmentProperty, thisAsIRxControl.HorizontalContentAlignment);
            SetPropertyValue(NativeControl, Control.IsEnabledProperty, thisAsIRxControl.IsEnabled);
            SetPropertyValue(NativeControl, Control.IsFocusEngagedProperty, thisAsIRxControl.IsFocusEngaged);
            SetPropertyValue(NativeControl, Control.IsFocusEngagementEnabledProperty, thisAsIRxControl.IsFocusEngagementEnabled);
            SetPropertyValue(NativeControl, Control.IsTextScaleFactorEnabledProperty, thisAsIRxControl.IsTextScaleFactorEnabled);
            SetPropertyValue(NativeControl, Control.PaddingProperty, thisAsIRxControl.Padding);
            SetPropertyValue(NativeControl, Control.RequiresPointerProperty, thisAsIRxControl.RequiresPointer);
            SetPropertyValue(NativeControl, Control.TabNavigationProperty, thisAsIRxControl.TabNavigation);
            SetPropertyValue(NativeControl, Control.VerticalContentAlignmentProperty, thisAsIRxControl.VerticalContentAlignment);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxControl = (IRxControl)this;

            base.OnAttachNativeEvents();

            OnEndAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            OnBeginDetachNativeEvents();

            if (NativeControl != null)
            {
            }

            base.OnDetachNativeEvents();

            OnEndDetachNativeEvents();
        }

        partial void OnBeginAttachNativeEvents();
        partial void OnEndAttachNativeEvents();
        partial void OnBeginDetachNativeEvents();
        partial void OnEndDetachNativeEvents();
    }
    public static partial class RxControlExtensions
    {
        public static T Background<T>(this T control, Brush background) where T : IRxControl
        {
            control.Background = new PropertyValue<Brush>(background);
            return control;
        }
        public static T Background<T>(this T control, Func<Brush> backgroundFunc) where T : IRxControl
        {
            control.Background = new PropertyValue<Brush>(backgroundFunc);
            return control;
        }
        public static T BackgroundSizing<T>(this T control, BackgroundSizing backgroundSizing) where T : IRxControl
        {
            control.BackgroundSizing = new PropertyValue<BackgroundSizing>(backgroundSizing);
            return control;
        }
        public static T BackgroundSizing<T>(this T control, Func<BackgroundSizing> backgroundSizingFunc) where T : IRxControl
        {
            control.BackgroundSizing = new PropertyValue<BackgroundSizing>(backgroundSizingFunc);
            return control;
        }
        public static T BorderBrush<T>(this T control, Brush borderBrush) where T : IRxControl
        {
            control.BorderBrush = new PropertyValue<Brush>(borderBrush);
            return control;
        }
        public static T BorderBrush<T>(this T control, Func<Brush> borderBrushFunc) where T : IRxControl
        {
            control.BorderBrush = new PropertyValue<Brush>(borderBrushFunc);
            return control;
        }
        public static T BorderThickness<T>(this T control, Thickness borderThickness) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(borderThickness);
            return control;
        }
        public static T BorderThickness<T>(this T control, Func<Thickness> borderThicknessFunc) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(borderThicknessFunc);
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
        public static T CharacterSpacing<T>(this T control, Func<int> characterSpacingFunc) where T : IRxControl
        {
            control.CharacterSpacing = new PropertyValue<int>(characterSpacingFunc);
            return control;
        }
        public static T CornerRadius<T>(this T control, CornerRadius cornerRadius) where T : IRxControl
        {
            control.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return control;
        }
        public static T CornerRadius<T>(this T control, Func<CornerRadius> cornerRadiusFunc) where T : IRxControl
        {
            control.CornerRadius = new PropertyValue<CornerRadius>(cornerRadiusFunc);
            return control;
        }
        public static T DefaultStyleResourceUri<T>(this T control, Uri defaultStyleResourceUri) where T : IRxControl
        {
            control.DefaultStyleResourceUri = new PropertyValue<Uri>(defaultStyleResourceUri);
            return control;
        }
        public static T DefaultStyleResourceUri<T>(this T control, Func<Uri> defaultStyleResourceUriFunc) where T : IRxControl
        {
            control.DefaultStyleResourceUri = new PropertyValue<Uri>(defaultStyleResourceUriFunc);
            return control;
        }
        public static T ElementSoundMode<T>(this T control, ElementSoundMode elementSoundMode) where T : IRxControl
        {
            control.ElementSoundMode = new PropertyValue<ElementSoundMode>(elementSoundMode);
            return control;
        }
        public static T ElementSoundMode<T>(this T control, Func<ElementSoundMode> elementSoundModeFunc) where T : IRxControl
        {
            control.ElementSoundMode = new PropertyValue<ElementSoundMode>(elementSoundModeFunc);
            return control;
        }
        public static T FontFamily<T>(this T control, FontFamily fontFamily) where T : IRxControl
        {
            control.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return control;
        }
        public static T FontFamily<T>(this T control, Func<FontFamily> fontFamilyFunc) where T : IRxControl
        {
            control.FontFamily = new PropertyValue<FontFamily>(fontFamilyFunc);
            return control;
        }
        public static T FontSize<T>(this T control, double fontSize) where T : IRxControl
        {
            control.FontSize = new PropertyValue<double>(fontSize);
            return control;
        }
        public static T FontSize<T>(this T control, Func<double> fontSizeFunc) where T : IRxControl
        {
            control.FontSize = new PropertyValue<double>(fontSizeFunc);
            return control;
        }
        public static T FontStretch<T>(this T control, FontStretch fontStretch) where T : IRxControl
        {
            control.FontStretch = new PropertyValue<FontStretch>(fontStretch);
            return control;
        }
        public static T FontStretch<T>(this T control, Func<FontStretch> fontStretchFunc) where T : IRxControl
        {
            control.FontStretch = new PropertyValue<FontStretch>(fontStretchFunc);
            return control;
        }
        public static T FontStyle<T>(this T control, FontStyle fontStyle) where T : IRxControl
        {
            control.FontStyle = new PropertyValue<FontStyle>(fontStyle);
            return control;
        }
        public static T FontStyle<T>(this T control, Func<FontStyle> fontStyleFunc) where T : IRxControl
        {
            control.FontStyle = new PropertyValue<FontStyle>(fontStyleFunc);
            return control;
        }
        public static T FontWeight<T>(this T control, FontWeight fontWeight) where T : IRxControl
        {
            control.FontWeight = new PropertyValue<FontWeight>(fontWeight);
            return control;
        }
        public static T FontWeight<T>(this T control, Func<FontWeight> fontWeightFunc) where T : IRxControl
        {
            control.FontWeight = new PropertyValue<FontWeight>(fontWeightFunc);
            return control;
        }
        public static T Foreground<T>(this T control, Brush foreground) where T : IRxControl
        {
            control.Foreground = new PropertyValue<Brush>(foreground);
            return control;
        }
        public static T Foreground<T>(this T control, Func<Brush> foregroundFunc) where T : IRxControl
        {
            control.Foreground = new PropertyValue<Brush>(foregroundFunc);
            return control;
        }
        public static T HorizontalContentAlignment<T>(this T control, HorizontalAlignment horizontalContentAlignment) where T : IRxControl
        {
            control.HorizontalContentAlignment = new PropertyValue<HorizontalAlignment>(horizontalContentAlignment);
            return control;
        }
        public static T HorizontalContentAlignment<T>(this T control, Func<HorizontalAlignment> horizontalContentAlignmentFunc) where T : IRxControl
        {
            control.HorizontalContentAlignment = new PropertyValue<HorizontalAlignment>(horizontalContentAlignmentFunc);
            return control;
        }
        public static T IsEnabled<T>(this T control, bool isEnabled) where T : IRxControl
        {
            control.IsEnabled = new PropertyValue<bool>(isEnabled);
            return control;
        }
        public static T IsEnabled<T>(this T control, Func<bool> isEnabledFunc) where T : IRxControl
        {
            control.IsEnabled = new PropertyValue<bool>(isEnabledFunc);
            return control;
        }
        public static T IsFocusEngaged<T>(this T control, bool isFocusEngaged) where T : IRxControl
        {
            control.IsFocusEngaged = new PropertyValue<bool>(isFocusEngaged);
            return control;
        }
        public static T IsFocusEngaged<T>(this T control, Func<bool> isFocusEngagedFunc) where T : IRxControl
        {
            control.IsFocusEngaged = new PropertyValue<bool>(isFocusEngagedFunc);
            return control;
        }
        public static T IsFocusEngagementEnabled<T>(this T control, bool isFocusEngagementEnabled) where T : IRxControl
        {
            control.IsFocusEngagementEnabled = new PropertyValue<bool>(isFocusEngagementEnabled);
            return control;
        }
        public static T IsFocusEngagementEnabled<T>(this T control, Func<bool> isFocusEngagementEnabledFunc) where T : IRxControl
        {
            control.IsFocusEngagementEnabled = new PropertyValue<bool>(isFocusEngagementEnabledFunc);
            return control;
        }
        public static T IsTextScaleFactorEnabled<T>(this T control, bool isTextScaleFactorEnabled) where T : IRxControl
        {
            control.IsTextScaleFactorEnabled = new PropertyValue<bool>(isTextScaleFactorEnabled);
            return control;
        }
        public static T IsTextScaleFactorEnabled<T>(this T control, Func<bool> isTextScaleFactorEnabledFunc) where T : IRxControl
        {
            control.IsTextScaleFactorEnabled = new PropertyValue<bool>(isTextScaleFactorEnabledFunc);
            return control;
        }
        public static T Padding<T>(this T control, Thickness padding) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(padding);
            return control;
        }
        public static T Padding<T>(this T control, Func<Thickness> paddingFunc) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(paddingFunc);
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
        public static T RequiresPointer<T>(this T control, Func<RequiresPointer> requiresPointerFunc) where T : IRxControl
        {
            control.RequiresPointer = new PropertyValue<RequiresPointer>(requiresPointerFunc);
            return control;
        }
        public static T TabNavigation<T>(this T control, KeyboardNavigationMode tabNavigation) where T : IRxControl
        {
            control.TabNavigation = new PropertyValue<KeyboardNavigationMode>(tabNavigation);
            return control;
        }
        public static T TabNavigation<T>(this T control, Func<KeyboardNavigationMode> tabNavigationFunc) where T : IRxControl
        {
            control.TabNavigation = new PropertyValue<KeyboardNavigationMode>(tabNavigationFunc);
            return control;
        }
        public static T VerticalContentAlignment<T>(this T control, VerticalAlignment verticalContentAlignment) where T : IRxControl
        {
            control.VerticalContentAlignment = new PropertyValue<VerticalAlignment>(verticalContentAlignment);
            return control;
        }
        public static T VerticalContentAlignment<T>(this T control, Func<VerticalAlignment> verticalContentAlignmentFunc) where T : IRxControl
        {
            control.VerticalContentAlignment = new PropertyValue<VerticalAlignment>(verticalContentAlignmentFunc);
            return control;
        }
    }
}
