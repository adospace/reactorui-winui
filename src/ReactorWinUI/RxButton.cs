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
    public partial interface IRxButton : IRxButtonBase
    {
        PropertyValue<FlyoutBase> Flyout { get; set; }

    }

    public partial class RxButton<T> : RxButtonBase<T>, IRxButton where T : Button, new()
    {
        public RxButton()
        {

        }

        public RxButton(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<FlyoutBase> IRxButton.Flyout { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxButton = (IRxButton)this;
            SetPropertyValue(NativeControl, Button.FlyoutProperty, thisAsIRxButton.Flyout);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxButton = (IRxButton)this;

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
    public partial class RxButton : RxButton<Button>
    {
        public RxButton()
        {

        }

        public RxButton(Action<Button> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxButtonExtensions
    {
        public static T Flyout<T>(this T button, FlyoutBase flyout) where T : IRxButton
        {
            button.Flyout = new PropertyValue<FlyoutBase>(flyout);
            return button;
        }
        public static T Flyout<T>(this T button, Func<FlyoutBase> flyoutFunc) where T : IRxButton
        {
            button.Flyout = new PropertyValue<FlyoutBase>(flyoutFunc);
            return button;
        }
    }
}
