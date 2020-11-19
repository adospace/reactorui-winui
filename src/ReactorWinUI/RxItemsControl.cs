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
    public partial interface IRxItemsControl : IRxControl
    {
        PropertyValue<string> DisplayMemberPath { get; set; }
        PropertyValue<Style> ItemContainerStyle { get; set; }
        PropertyValue<TransitionCollection> ItemContainerTransitions { get; set; }

    }

    public partial class RxItemsControl<T> : RxControl<T>, IRxItemsControl where T : ItemsControl, new()
    {
        public RxItemsControl()
        {

        }

        public RxItemsControl(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<string> IRxItemsControl.DisplayMemberPath { get; set; }
        PropertyValue<Style> IRxItemsControl.ItemContainerStyle { get; set; }
        PropertyValue<TransitionCollection> IRxItemsControl.ItemContainerTransitions { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxItemsControl = (IRxItemsControl)this;
            NativeControl.Set(this, ItemsControl.DisplayMemberPathProperty, thisAsIRxItemsControl.DisplayMemberPath);
            NativeControl.Set(this, ItemsControl.ItemContainerStyleProperty, thisAsIRxItemsControl.ItemContainerStyle);
            NativeControl.Set(this, ItemsControl.ItemContainerTransitionsProperty, thisAsIRxItemsControl.ItemContainerTransitions);
            //NativeControl.Set(this, ItemsControl.ItemsSourceProperty, thisAsIRxItemsControl.ItemsSource);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxItemsControl = (IRxItemsControl)this;

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
    public partial class RxItemsControl : RxItemsControl<ItemsControl>
    {
        public RxItemsControl()
        {

        }

        public RxItemsControl(Action<ItemsControl> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxItemsControlExtensions
    {
        public static T DisplayMemberPath<T>(this T itemscontrol, string displayMemberPath) where T : IRxItemsControl
        {
            itemscontrol.DisplayMemberPath = new PropertyValue<string>(displayMemberPath);
            return itemscontrol;
        }
        public static T ItemContainerStyle<T>(this T itemscontrol, Style itemContainerStyle) where T : IRxItemsControl
        {
            itemscontrol.ItemContainerStyle = new PropertyValue<Style>(itemContainerStyle);
            return itemscontrol;
        }
        public static T ItemContainerTransitions<T>(this T itemscontrol, TransitionCollection itemContainerTransitions) where T : IRxItemsControl
        {
            itemscontrol.ItemContainerTransitions = new PropertyValue<TransitionCollection>(itemContainerTransitions);
            return itemscontrol;
        }

    }
}
