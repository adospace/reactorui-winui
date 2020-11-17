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
    public partial interface IRxTextBlock : IRxFrameworkElement
    {
        PropertyValue<int> CharacterSpacing { get; set; }
        PropertyValue<FontFamily> FontFamily { get; set; }
        PropertyValue<double> FontSize { get; set; }
        PropertyValue<FontStretch> FontStretch { get; set; }
        PropertyValue<FontStyle> FontStyle { get; set; }
        PropertyValue<FontWeight> FontWeight { get; set; }
        PropertyValue<Brush> Foreground { get; set; }
        PropertyValue<TextAlignment> HorizontalTextAlignment { get; set; }
        PropertyValue<bool> IsColorFontEnabled { get; set; }
        PropertyValue<bool> IsTextScaleFactorEnabled { get; set; }
        PropertyValue<bool> IsTextSelectionEnabled { get; set; }
        PropertyValue<double> LineHeight { get; set; }
        PropertyValue<LineStackingStrategy> LineStackingStrategy { get; set; }
        PropertyValue<int> MaxLines { get; set; }
        PropertyValue<OpticalMarginAlignment> OpticalMarginAlignment { get; set; }
        PropertyValue<Thickness> Padding { get; set; }
        PropertyValue<FlyoutBase> SelectionFlyout { get; set; }
        PropertyValue<SolidColorBrush> SelectionHighlightColor { get; set; }
        PropertyValue<string> Text { get; set; }
        PropertyValue<TextAlignment> TextAlignment { get; set; }
        PropertyValue<TextDecorations> TextDecorations { get; set; }
        PropertyValue<TextLineBounds> TextLineBounds { get; set; }
        PropertyValue<TextReadingOrder> TextReadingOrder { get; set; }
        PropertyValue<TextTrimming> TextTrimming { get; set; }
        PropertyValue<TextWrapping> TextWrapping { get; set; }

        Action SelectionChangedAction { get; set; }
        Action<object, RoutedEventArgs> SelectionChangedActionWithArgs { get; set; }
    }

    public partial class RxTextBlock : RxFrameworkElement<TextBlock>, IRxTextBlock
    {
        public RxTextBlock()
        {

        }

        public RxTextBlock(Action<TextBlock> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<int> IRxTextBlock.CharacterSpacing { get; set; }
        PropertyValue<FontFamily> IRxTextBlock.FontFamily { get; set; }
        PropertyValue<double> IRxTextBlock.FontSize { get; set; }
        PropertyValue<FontStretch> IRxTextBlock.FontStretch { get; set; }
        PropertyValue<FontStyle> IRxTextBlock.FontStyle { get; set; }
        PropertyValue<FontWeight> IRxTextBlock.FontWeight { get; set; }
        PropertyValue<Brush> IRxTextBlock.Foreground { get; set; }
        PropertyValue<TextAlignment> IRxTextBlock.HorizontalTextAlignment { get; set; }
        PropertyValue<bool> IRxTextBlock.IsColorFontEnabled { get; set; }
        PropertyValue<bool> IRxTextBlock.IsTextScaleFactorEnabled { get; set; }
        PropertyValue<bool> IRxTextBlock.IsTextSelectionEnabled { get; set; }
        PropertyValue<double> IRxTextBlock.LineHeight { get; set; }
        PropertyValue<LineStackingStrategy> IRxTextBlock.LineStackingStrategy { get; set; }
        PropertyValue<int> IRxTextBlock.MaxLines { get; set; }
        PropertyValue<OpticalMarginAlignment> IRxTextBlock.OpticalMarginAlignment { get; set; }
        PropertyValue<Thickness> IRxTextBlock.Padding { get; set; }
        PropertyValue<FlyoutBase> IRxTextBlock.SelectionFlyout { get; set; }
        PropertyValue<SolidColorBrush> IRxTextBlock.SelectionHighlightColor { get; set; }
        PropertyValue<string> IRxTextBlock.Text { get; set; }
        PropertyValue<TextAlignment> IRxTextBlock.TextAlignment { get; set; }
        PropertyValue<TextDecorations> IRxTextBlock.TextDecorations { get; set; }
        PropertyValue<TextLineBounds> IRxTextBlock.TextLineBounds { get; set; }
        PropertyValue<TextReadingOrder> IRxTextBlock.TextReadingOrder { get; set; }
        PropertyValue<TextTrimming> IRxTextBlock.TextTrimming { get; set; }
        PropertyValue<TextWrapping> IRxTextBlock.TextWrapping { get; set; }

        Action IRxTextBlock.SelectionChangedAction { get; set; }
        Action<object, RoutedEventArgs> IRxTextBlock.SelectionChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTextBlock = (IRxTextBlock)this;
            NativeControl.Set(this, TextBlock.CharacterSpacingProperty, thisAsIRxTextBlock.CharacterSpacing);
            NativeControl.Set(this, TextBlock.FontFamilyProperty, thisAsIRxTextBlock.FontFamily);
            NativeControl.Set(this, TextBlock.FontSizeProperty, thisAsIRxTextBlock.FontSize);
            NativeControl.Set(this, TextBlock.FontStretchProperty, thisAsIRxTextBlock.FontStretch);
            NativeControl.Set(this, TextBlock.FontStyleProperty, thisAsIRxTextBlock.FontStyle);
            NativeControl.Set(this, TextBlock.FontWeightProperty, thisAsIRxTextBlock.FontWeight);
            NativeControl.Set(this, TextBlock.ForegroundProperty, thisAsIRxTextBlock.Foreground);
            NativeControl.Set(this, TextBlock.HorizontalTextAlignmentProperty, thisAsIRxTextBlock.HorizontalTextAlignment);
            NativeControl.Set(this, TextBlock.IsColorFontEnabledProperty, thisAsIRxTextBlock.IsColorFontEnabled);
            NativeControl.Set(this, TextBlock.IsTextScaleFactorEnabledProperty, thisAsIRxTextBlock.IsTextScaleFactorEnabled);
            NativeControl.Set(this, TextBlock.IsTextSelectionEnabledProperty, thisAsIRxTextBlock.IsTextSelectionEnabled);
            NativeControl.Set(this, TextBlock.LineHeightProperty, thisAsIRxTextBlock.LineHeight);
            NativeControl.Set(this, TextBlock.LineStackingStrategyProperty, thisAsIRxTextBlock.LineStackingStrategy);
            NativeControl.Set(this, TextBlock.MaxLinesProperty, thisAsIRxTextBlock.MaxLines);
            NativeControl.Set(this, TextBlock.OpticalMarginAlignmentProperty, thisAsIRxTextBlock.OpticalMarginAlignment);
            NativeControl.Set(this, TextBlock.PaddingProperty, thisAsIRxTextBlock.Padding);
            NativeControl.Set(this, TextBlock.SelectionFlyoutProperty, thisAsIRxTextBlock.SelectionFlyout);
            NativeControl.Set(this, TextBlock.SelectionHighlightColorProperty, thisAsIRxTextBlock.SelectionHighlightColor);
            NativeControl.Set(this, TextBlock.TextProperty, thisAsIRxTextBlock.Text);
            NativeControl.Set(this, TextBlock.TextAlignmentProperty, thisAsIRxTextBlock.TextAlignment);
            NativeControl.Set(this, TextBlock.TextDecorationsProperty, thisAsIRxTextBlock.TextDecorations);
            NativeControl.Set(this, TextBlock.TextLineBoundsProperty, thisAsIRxTextBlock.TextLineBounds);
            NativeControl.Set(this, TextBlock.TextReadingOrderProperty, thisAsIRxTextBlock.TextReadingOrder);
            NativeControl.Set(this, TextBlock.TextTrimmingProperty, thisAsIRxTextBlock.TextTrimming);
            NativeControl.Set(this, TextBlock.TextWrappingProperty, thisAsIRxTextBlock.TextWrapping);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxTextBlock = (IRxTextBlock)this;
            if (thisAsIRxTextBlock.SelectionChangedAction != null || thisAsIRxTextBlock.SelectionChangedActionWithArgs != null)
            {
                NativeControl.SelectionChanged += NativeControl_SelectionChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var thisAsIRxTextBlock = (IRxTextBlock)this;
            thisAsIRxTextBlock.SelectionChangedAction?.Invoke();
            thisAsIRxTextBlock.SelectionChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.SelectionChanged -= NativeControl_SelectionChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxTextBlockExtensions
    {
        public static T CharacterSpacing<T>(this T textblock, int characterSpacing) where T : IRxTextBlock
        {
            textblock.CharacterSpacing = new PropertyValue<int>(characterSpacing);
            return textblock;
        }
        public static T FontFamily<T>(this T textblock, FontFamily fontFamily) where T : IRxTextBlock
        {
            textblock.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return textblock;
        }
        public static T FontSize<T>(this T textblock, double fontSize) where T : IRxTextBlock
        {
            textblock.FontSize = new PropertyValue<double>(fontSize);
            return textblock;
        }
        public static T FontStretch<T>(this T textblock, FontStretch fontStretch) where T : IRxTextBlock
        {
            textblock.FontStretch = new PropertyValue<FontStretch>(fontStretch);
            return textblock;
        }
        public static T FontStyle<T>(this T textblock, FontStyle fontStyle) where T : IRxTextBlock
        {
            textblock.FontStyle = new PropertyValue<FontStyle>(fontStyle);
            return textblock;
        }
        public static T FontWeight<T>(this T textblock, FontWeight fontWeight) where T : IRxTextBlock
        {
            textblock.FontWeight = new PropertyValue<FontWeight>(fontWeight);
            return textblock;
        }
        public static T Foreground<T>(this T textblock, Brush foreground) where T : IRxTextBlock
        {
            textblock.Foreground = new PropertyValue<Brush>(foreground);
            return textblock;
        }
        public static T HorizontalTextAlignment<T>(this T textblock, TextAlignment horizontalTextAlignment) where T : IRxTextBlock
        {
            textblock.HorizontalTextAlignment = new PropertyValue<TextAlignment>(horizontalTextAlignment);
            return textblock;
        }
        public static T IsColorFontEnabled<T>(this T textblock, bool isColorFontEnabled) where T : IRxTextBlock
        {
            textblock.IsColorFontEnabled = new PropertyValue<bool>(isColorFontEnabled);
            return textblock;
        }
        public static T IsTextScaleFactorEnabled<T>(this T textblock, bool isTextScaleFactorEnabled) where T : IRxTextBlock
        {
            textblock.IsTextScaleFactorEnabled = new PropertyValue<bool>(isTextScaleFactorEnabled);
            return textblock;
        }
        public static T IsTextSelectionEnabled<T>(this T textblock, bool isTextSelectionEnabled) where T : IRxTextBlock
        {
            textblock.IsTextSelectionEnabled = new PropertyValue<bool>(isTextSelectionEnabled);
            return textblock;
        }
        public static T LineHeight<T>(this T textblock, double lineHeight) where T : IRxTextBlock
        {
            textblock.LineHeight = new PropertyValue<double>(lineHeight);
            return textblock;
        }
        public static T LineStackingStrategy<T>(this T textblock, LineStackingStrategy lineStackingStrategy) where T : IRxTextBlock
        {
            textblock.LineStackingStrategy = new PropertyValue<LineStackingStrategy>(lineStackingStrategy);
            return textblock;
        }
        public static T MaxLines<T>(this T textblock, int maxLines) where T : IRxTextBlock
        {
            textblock.MaxLines = new PropertyValue<int>(maxLines);
            return textblock;
        }
        public static T OpticalMarginAlignment<T>(this T textblock, OpticalMarginAlignment opticalMarginAlignment) where T : IRxTextBlock
        {
            textblock.OpticalMarginAlignment = new PropertyValue<OpticalMarginAlignment>(opticalMarginAlignment);
            return textblock;
        }
        public static T Padding<T>(this T textblock, Thickness padding) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(padding);
            return textblock;
        }
        public static T Padding<T>(this T textblock, double leftRight, double topBottom) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return textblock;
        }
        public static T Padding<T>(this T textblock, double uniformSize) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return textblock;
        }
        public static T SelectionFlyout<T>(this T textblock, FlyoutBase selectionFlyout) where T : IRxTextBlock
        {
            textblock.SelectionFlyout = new PropertyValue<FlyoutBase>(selectionFlyout);
            return textblock;
        }
        public static T SelectionHighlightColor<T>(this T textblock, SolidColorBrush selectionHighlightColor) where T : IRxTextBlock
        {
            textblock.SelectionHighlightColor = new PropertyValue<SolidColorBrush>(selectionHighlightColor);
            return textblock;
        }
        public static T Text<T>(this T textblock, string text) where T : IRxTextBlock
        {
            textblock.Text = new PropertyValue<string>(text);
            return textblock;
        }
        public static T TextAlignment<T>(this T textblock, TextAlignment textAlignment) where T : IRxTextBlock
        {
            textblock.TextAlignment = new PropertyValue<TextAlignment>(textAlignment);
            return textblock;
        }
        public static T TextDecorations<T>(this T textblock, TextDecorations textDecorations) where T : IRxTextBlock
        {
            textblock.TextDecorations = new PropertyValue<TextDecorations>(textDecorations);
            return textblock;
        }
        public static T TextLineBounds<T>(this T textblock, TextLineBounds textLineBounds) where T : IRxTextBlock
        {
            textblock.TextLineBounds = new PropertyValue<TextLineBounds>(textLineBounds);
            return textblock;
        }
        public static T TextReadingOrder<T>(this T textblock, TextReadingOrder textReadingOrder) where T : IRxTextBlock
        {
            textblock.TextReadingOrder = new PropertyValue<TextReadingOrder>(textReadingOrder);
            return textblock;
        }
        public static T TextTrimming<T>(this T textblock, TextTrimming textTrimming) where T : IRxTextBlock
        {
            textblock.TextTrimming = new PropertyValue<TextTrimming>(textTrimming);
            return textblock;
        }
        public static T TextWrapping<T>(this T textblock, TextWrapping textWrapping) where T : IRxTextBlock
        {
            textblock.TextWrapping = new PropertyValue<TextWrapping>(textWrapping);
            return textblock;
        }
        public static T OnSelectionChanged<T>(this T textblock, Action selectionchangedAction) where T : IRxTextBlock
        {
            textblock.SelectionChangedAction = selectionchangedAction;
            return textblock;
        }

        public static T OnSelectionChanged<T>(this T textblock, Action<object, RoutedEventArgs> selectionchangedActionWithArgs) where T : IRxTextBlock
        {
            textblock.SelectionChangedActionWithArgs = selectionchangedActionWithArgs;
            return textblock;
        }
    }
}
