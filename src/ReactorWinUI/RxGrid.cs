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
            SetPropertyValue(NativeControl, Grid.BackgroundSizingProperty, thisAsIRxGrid.BackgroundSizing);
            SetPropertyValue(NativeControl, Grid.BorderBrushProperty, thisAsIRxGrid.BorderBrush);
            SetPropertyValue(NativeControl, Grid.BorderThicknessProperty, thisAsIRxGrid.BorderThickness);
            SetPropertyValue(NativeControl, Grid.ColumnSpacingProperty, thisAsIRxGrid.ColumnSpacing);
            SetPropertyValue(NativeControl, Grid.CornerRadiusProperty, thisAsIRxGrid.CornerRadius);
            SetPropertyValue(NativeControl, Grid.PaddingProperty, thisAsIRxGrid.Padding);
            SetPropertyValue(NativeControl, Grid.RowSpacingProperty, thisAsIRxGrid.RowSpacing);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxGrid = (IRxGrid)this;

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
        public static T BackgroundSizing<T>(this T grid, Func<BackgroundSizing> backgroundSizingFunc) where T : IRxGrid
        {
            grid.BackgroundSizing = new PropertyValue<BackgroundSizing>(backgroundSizingFunc);
            return grid;
        }
        public static T BorderBrush<T>(this T grid, Brush borderBrush) where T : IRxGrid
        {
            grid.BorderBrush = new PropertyValue<Brush>(borderBrush);
            return grid;
        }
        public static T BorderBrush<T>(this T grid, Func<Brush> borderBrushFunc) where T : IRxGrid
        {
            grid.BorderBrush = new PropertyValue<Brush>(borderBrushFunc);
            return grid;
        }
        public static T BorderThickness<T>(this T grid, Thickness borderThickness) where T : IRxGrid
        {
            grid.BorderThickness = new PropertyValue<Thickness>(borderThickness);
            return grid;
        }
        public static T BorderThickness<T>(this T grid, Func<Thickness> borderThicknessFunc) where T : IRxGrid
        {
            grid.BorderThickness = new PropertyValue<Thickness>(borderThicknessFunc);
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
        public static T ColumnSpacing<T>(this T grid, Func<double> columnSpacingFunc) where T : IRxGrid
        {
            grid.ColumnSpacing = new PropertyValue<double>(columnSpacingFunc);
            return grid;
        }
        public static T CornerRadius<T>(this T grid, CornerRadius cornerRadius) where T : IRxGrid
        {
            grid.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return grid;
        }
        public static T CornerRadius<T>(this T grid, Func<CornerRadius> cornerRadiusFunc) where T : IRxGrid
        {
            grid.CornerRadius = new PropertyValue<CornerRadius>(cornerRadiusFunc);
            return grid;
        }
        public static T Padding<T>(this T grid, Thickness padding) where T : IRxGrid
        {
            grid.Padding = new PropertyValue<Thickness>(padding);
            return grid;
        }
        public static T Padding<T>(this T grid, Func<Thickness> paddingFunc) where T : IRxGrid
        {
            grid.Padding = new PropertyValue<Thickness>(paddingFunc);
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
        public static T RowSpacing<T>(this T grid, Func<double> rowSpacingFunc) where T : IRxGrid
        {
            grid.RowSpacing = new PropertyValue<double>(rowSpacingFunc);
            return grid;
        }
    }
}
