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
    public partial interface IRxStackPanel : IRxPanel
    {
        PropertyValue<bool> AreScrollSnapPointsRegular { get; set; }
        PropertyValue<BackgroundSizing> BackgroundSizing { get; set; }
        PropertyValue<Brush> BorderBrush { get; set; }
        PropertyValue<Thickness> BorderThickness { get; set; }
        PropertyValue<CornerRadius> CornerRadius { get; set; }
        PropertyValue<Orientation> Orientation { get; set; }
        PropertyValue<Thickness> Padding { get; set; }
        PropertyValue<double> Spacing { get; set; }

    }

    public partial class RxStackPanel<T> : RxPanel<T>, IRxStackPanel where T : StackPanel, new()
    {
        public RxStackPanel()
        {

        }

        public RxStackPanel(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<bool> IRxStackPanel.AreScrollSnapPointsRegular { get; set; }
        PropertyValue<BackgroundSizing> IRxStackPanel.BackgroundSizing { get; set; }
        PropertyValue<Brush> IRxStackPanel.BorderBrush { get; set; }
        PropertyValue<Thickness> IRxStackPanel.BorderThickness { get; set; }
        PropertyValue<CornerRadius> IRxStackPanel.CornerRadius { get; set; }
        PropertyValue<Orientation> IRxStackPanel.Orientation { get; set; }
        PropertyValue<Thickness> IRxStackPanel.Padding { get; set; }
        PropertyValue<double> IRxStackPanel.Spacing { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxStackPanel = (IRxStackPanel)this;
            NativeControl.Set(this, StackPanel.AreScrollSnapPointsRegularProperty, thisAsIRxStackPanel.AreScrollSnapPointsRegular);
            NativeControl.Set(this, StackPanel.BackgroundSizingProperty, thisAsIRxStackPanel.BackgroundSizing);
            NativeControl.Set(this, StackPanel.BorderBrushProperty, thisAsIRxStackPanel.BorderBrush);
            NativeControl.Set(this, StackPanel.BorderThicknessProperty, thisAsIRxStackPanel.BorderThickness);
            NativeControl.Set(this, StackPanel.CornerRadiusProperty, thisAsIRxStackPanel.CornerRadius);
            NativeControl.Set(this, StackPanel.OrientationProperty, thisAsIRxStackPanel.Orientation);
            NativeControl.Set(this, StackPanel.PaddingProperty, thisAsIRxStackPanel.Padding);
            NativeControl.Set(this, StackPanel.SpacingProperty, thisAsIRxStackPanel.Spacing);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxStackPanel = (IRxStackPanel)this;

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
    public partial class RxStackPanel : RxStackPanel<StackPanel>
    {
        public RxStackPanel()
        {

        }

        public RxStackPanel(Action<StackPanel> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxStackPanelExtensions
    {
        public static T AreScrollSnapPointsRegular<T>(this T stackpanel, bool areScrollSnapPointsRegular) where T : IRxStackPanel
        {
            stackpanel.AreScrollSnapPointsRegular = new PropertyValue<bool>(areScrollSnapPointsRegular);
            return stackpanel;
        }
        public static T BackgroundSizing<T>(this T stackpanel, BackgroundSizing backgroundSizing) where T : IRxStackPanel
        {
            stackpanel.BackgroundSizing = new PropertyValue<BackgroundSizing>(backgroundSizing);
            return stackpanel;
        }
        public static T BorderBrush<T>(this T stackpanel, Brush borderBrush) where T : IRxStackPanel
        {
            stackpanel.BorderBrush = new PropertyValue<Brush>(borderBrush);
            return stackpanel;
        }
        public static T BorderThickness<T>(this T stackpanel, Thickness borderThickness) where T : IRxStackPanel
        {
            stackpanel.BorderThickness = new PropertyValue<Thickness>(borderThickness);
            return stackpanel;
        }
        public static T BorderThickness<T>(this T stackpanel, double leftRight, double topBottom) where T : IRxStackPanel
        {
            stackpanel.BorderThickness = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return stackpanel;
        }
        public static T BorderThickness<T>(this T stackpanel, double uniformSize) where T : IRxStackPanel
        {
            stackpanel.BorderThickness = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return stackpanel;
        }
        public static T CornerRadius<T>(this T stackpanel, CornerRadius cornerRadius) where T : IRxStackPanel
        {
            stackpanel.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return stackpanel;
        }
        public static T Orientation<T>(this T stackpanel, Orientation orientation) where T : IRxStackPanel
        {
            stackpanel.Orientation = new PropertyValue<Orientation>(orientation);
            return stackpanel;
        }
        public static T Padding<T>(this T stackpanel, Thickness padding) where T : IRxStackPanel
        {
            stackpanel.Padding = new PropertyValue<Thickness>(padding);
            return stackpanel;
        }
        public static T Padding<T>(this T stackpanel, double leftRight, double topBottom) where T : IRxStackPanel
        {
            stackpanel.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return stackpanel;
        }
        public static T Padding<T>(this T stackpanel, double uniformSize) where T : IRxStackPanel
        {
            stackpanel.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return stackpanel;
        }
        public static T Spacing<T>(this T stackpanel, double spacing) where T : IRxStackPanel
        {
            stackpanel.Spacing = new PropertyValue<double>(spacing);
            return stackpanel;
        }
    }
}
