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
    public partial interface IRxSelector : IRxItemsControl
    {
        PropertyValue<int> SelectedIndex { get; set; }
        PropertyValue<object> SelectedItem { get; set; }
        PropertyValue<object> SelectedValue { get; set; }
        PropertyValue<string> SelectedValuePath { get; set; }

    }

    public partial class RxSelector<T> : RxItemsControl<T>, IRxSelector where T : Selector, new()
    {
        public RxSelector()
        {

        }

        public RxSelector(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<int> IRxSelector.SelectedIndex { get; set; }
        PropertyValue<object> IRxSelector.SelectedItem { get; set; }
        PropertyValue<object> IRxSelector.SelectedValue { get; set; }
        PropertyValue<string> IRxSelector.SelectedValuePath { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxSelector = (IRxSelector)this;
            SetPropertyValue(NativeControl, Selector.SelectedIndexProperty, thisAsIRxSelector.SelectedIndex);
            SetPropertyValue(NativeControl, Selector.SelectedItemProperty, thisAsIRxSelector.SelectedItem);
            SetPropertyValue(NativeControl, Selector.SelectedValueProperty, thisAsIRxSelector.SelectedValue);
            SetPropertyValue(NativeControl, Selector.SelectedValuePathProperty, thisAsIRxSelector.SelectedValuePath);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxSelector = (IRxSelector)this;

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
    public static partial class RxSelectorExtensions
    {
        public static T SelectedIndex<T>(this T selector, int selectedIndex) where T : IRxSelector
        {
            selector.SelectedIndex = new PropertyValue<int>(selectedIndex);
            return selector;
        }
        public static T SelectedIndex<T>(this T selector, Func<int> selectedIndexFunc) where T : IRxSelector
        {
            selector.SelectedIndex = new PropertyValue<int>(selectedIndexFunc);
            return selector;
        }
        public static T SelectedItem<T>(this T selector, object selectedItem) where T : IRxSelector
        {
            selector.SelectedItem = new PropertyValue<object>(selectedItem);
            return selector;
        }
        public static T SelectedItem<T>(this T selector, Func<object> selectedItemFunc) where T : IRxSelector
        {
            selector.SelectedItem = new PropertyValue<object>(selectedItemFunc);
            return selector;
        }
        public static T SelectedValue<T>(this T selector, object selectedValue) where T : IRxSelector
        {
            selector.SelectedValue = new PropertyValue<object>(selectedValue);
            return selector;
        }
        public static T SelectedValue<T>(this T selector, Func<object> selectedValueFunc) where T : IRxSelector
        {
            selector.SelectedValue = new PropertyValue<object>(selectedValueFunc);
            return selector;
        }
        public static T SelectedValuePath<T>(this T selector, string selectedValuePath) where T : IRxSelector
        {
            selector.SelectedValuePath = new PropertyValue<string>(selectedValuePath);
            return selector;
        }
        public static T SelectedValuePath<T>(this T selector, Func<string> selectedValuePathFunc) where T : IRxSelector
        {
            selector.SelectedValuePath = new PropertyValue<string>(selectedValuePathFunc);
            return selector;
        }
    }
}
