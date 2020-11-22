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
    public partial interface IRxGrid : IRxPanel
    {
        PropertyValue<BackgroundSizing> BackgroundSizing { get; set; }
        PropertyValue<Brush> BorderBrush { get; set; }
        PropertyValue<Thickness> BorderThickness { get; set; }
        PropertyValue<double> ColumnSpacing { get; set; }
        PropertyValue<CornerRadius> CornerRadius { get; set; }
        PropertyValue<Thickness> Padding { get; set; }
        PropertyValue<double> RowSpacing { get; set; }

    }

    public partial class RxGrid<T> : RxPanel<T>, IRxGrid where T : Grid, new()
    {
        public RxGrid()
        {

        }

        public RxGrid(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<BackgroundSizing> IRxGrid.BackgroundSizing { get; set; }
        PropertyValue<Brush> IRxGrid.BorderBrush { get; set; }
        PropertyValue<Thickness> IRxGrid.BorderThickness { get; set; }
        PropertyValue<double> IRxGrid.ColumnSpacing { get; set; }
        PropertyValue<CornerRadius> IRxGrid.CornerRadius { get; set; }
        PropertyValue<Thickness> IRxGrid.Padding { get; set; }
        PropertyValue<double> IRxGrid.RowSpacing { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxGrid = (IRxGrid)this;
            NativeControl.Set(this, Grid.BackgroundSizingProperty, thisAsIRxGrid.BackgroundSizing);
            NativeControl.Set(this, Grid.BorderBrushProperty, thisAsIRxGrid.BorderBrush);
            NativeControl.Set(this, Grid.BorderThicknessProperty, thisAsIRxGrid.BorderThickness);
            NativeControl.Set(this, Grid.ColumnSpacingProperty, thisAsIRxGrid.ColumnSpacing);
            NativeControl.Set(this, Grid.CornerRadiusProperty, thisAsIRxGrid.CornerRadius);
            NativeControl.Set(this, Grid.PaddingProperty, thisAsIRxGrid.Padding);
            NativeControl.Set(this, Grid.RowSpacingProperty, thisAsIRxGrid.RowSpacing);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxGrid = (IRxGrid)this;

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
    public partial class RxGrid : RxGrid<Grid>
    {
        public RxGrid()
        {

        }

        public RxGrid(Action<Grid> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxGridExtensions
    {
        public static T BackgroundSizing<T>(this T grid, BackgroundSizing backgroundSizing) where T : IRxGrid
        {
            grid.BackgroundSizing = new PropertyValue<BackgroundSizing>(backgroundSizing);
            return grid;
        }
        public static T BorderBrush<T>(this T grid, Brush borderBrush) where T : IRxGrid
        {
            grid.BorderBrush = new PropertyValue<Brush>(borderBrush);
            return grid;
        }
        public static T BorderThickness<T>(this T grid, Thickness borderThickness) where T : IRxGrid
        {
            grid.BorderThickness = new PropertyValue<Thickness>(borderThickness);
            return grid;
        }
        public static T BorderThickness<T>(this T grid, double leftRight, double topBottom) where T : IRxGrid
        {
            grid.BorderThickness = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return grid;
        }
        public static T BorderThickness<T>(this T grid, double uniformSize) where T : IRxGrid
        {
            grid.BorderThickness = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return grid;
        }
        public static T ColumnSpacing<T>(this T grid, double columnSpacing) where T : IRxGrid
        {
            grid.ColumnSpacing = new PropertyValue<double>(columnSpacing);
            return grid;
        }
        public static T CornerRadius<T>(this T grid, CornerRadius cornerRadius) where T : IRxGrid
        {
            grid.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return grid;
        }
        public static T Padding<T>(this T grid, Thickness padding) where T : IRxGrid
        {
            grid.Padding = new PropertyValue<Thickness>(padding);
            return grid;
        }
        public static T Padding<T>(this T grid, double leftRight, double topBottom) where T : IRxGrid
        {
            grid.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return grid;
        }
        public static T Padding<T>(this T grid, double uniformSize) where T : IRxGrid
        {
            grid.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return grid;
        }
        public static T RowSpacing<T>(this T grid, double rowSpacing) where T : IRxGrid
        {
            grid.RowSpacing = new PropertyValue<double>(rowSpacing);
            return grid;
        }
    }
}
