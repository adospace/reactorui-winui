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
    public partial interface IRxContentControl : IRxControl
    {
        PropertyValue<object> Content { get; set; }
        PropertyValue<TransitionCollection> ContentTransitions { get; set; }

    }

    public partial class RxContentControl<T> : RxControl<T>, IRxContentControl where T : ContentControl, new()
    {
        public RxContentControl()
        {

        }

        public RxContentControl(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<object> IRxContentControl.Content { get; set; }
        PropertyValue<TransitionCollection> IRxContentControl.ContentTransitions { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxContentControl = (IRxContentControl)this;
            NativeControl.Set(this, ContentControl.ContentProperty, thisAsIRxContentControl.Content);
            NativeControl.Set(this, ContentControl.ContentTransitionsProperty, thisAsIRxContentControl.ContentTransitions);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxContentControl = (IRxContentControl)this;

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
    public partial class RxContentControl : RxContentControl<ContentControl>
    {
        public RxContentControl()
        {

        }

        public RxContentControl(Action<ContentControl> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxContentControlExtensions
    {
        public static T Content<T>(this T contentcontrol, object content) where T : IRxContentControl
        {
            contentcontrol.Content = new PropertyValue<object>(content);
            return contentcontrol;
        }
        public static T ContentTransitions<T>(this T contentcontrol, TransitionCollection contentTransitions) where T : IRxContentControl
        {
            contentcontrol.ContentTransitions = new PropertyValue<TransitionCollection>(contentTransitions);
            return contentcontrol;
        }
    }
}
