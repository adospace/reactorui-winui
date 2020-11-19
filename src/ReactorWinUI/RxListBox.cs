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
    public partial interface IRxListBox : IRxSelector
    {
        PropertyValue<SelectionMode> SelectionMode { get; set; }
        PropertyValue<bool> SingleSelectionFollowsFocus { get; set; }

    }

    public partial class RxListBox<T> : RxSelector<T>, IRxListBox where T : ListBox, new()
    {
        public RxListBox()
        {

        }

        public RxListBox(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<SelectionMode> IRxListBox.SelectionMode { get; set; }
        PropertyValue<bool> IRxListBox.SingleSelectionFollowsFocus { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxListBox = (IRxListBox)this;
            NativeControl.Set(this, ListBox.SelectionModeProperty, thisAsIRxListBox.SelectionMode);
            NativeControl.Set(this, ListBox.SingleSelectionFollowsFocusProperty, thisAsIRxListBox.SingleSelectionFollowsFocus);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxListBox = (IRxListBox)this;

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
    public partial class RxListBox : RxListBox<ListBox>
    {
        public RxListBox()
        {

        }

        public RxListBox(Action<ListBox> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxListBoxExtensions
    {
        public static T SelectionMode<T>(this T listbox, SelectionMode selectionMode) where T : IRxListBox
        {
            listbox.SelectionMode = new PropertyValue<SelectionMode>(selectionMode);
            return listbox;
        }
        public static T SingleSelectionFollowsFocus<T>(this T listbox, bool singleSelectionFollowsFocus) where T : IRxListBox
        {
            listbox.SingleSelectionFollowsFocus = new PropertyValue<bool>(singleSelectionFollowsFocus);
            return listbox;
        }
    }
}
