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
    public partial interface IRxUserControl : IRxControl
    {
        PropertyValue<UIElement> Content { get; set; }

    }

    public partial class RxUserControl<T> : RxControl<T>, IRxUserControl where T : UserControl, new()
    {
        public RxUserControl()
        {

        }

        public RxUserControl(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<UIElement> IRxUserControl.Content { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxUserControl = (IRxUserControl)this;
            NativeControl.Set(this, UserControl.ContentProperty, thisAsIRxUserControl.Content);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxUserControl = (IRxUserControl)this;

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
    public partial class RxUserControl : RxUserControl<UserControl>
    {
        public RxUserControl()
        {

        }

        public RxUserControl(Action<UserControl> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxUserControlExtensions
    {
        public static T Content<T>(this T usercontrol, UIElement content) where T : IRxUserControl
        {
            usercontrol.Content = new PropertyValue<UIElement>(content);
            return usercontrol;
        }
    }
}
