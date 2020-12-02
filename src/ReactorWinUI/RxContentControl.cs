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
            SetPropertyValue(NativeControl, ContentControl.ContentProperty, thisAsIRxContentControl.Content);
            SetPropertyValue(NativeControl, ContentControl.ContentTransitionsProperty, thisAsIRxContentControl.ContentTransitions);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxContentControl = (IRxContentControl)this;

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
        public static T Content<T>(this T contentcontrol, Func<object> contentFunc) where T : IRxContentControl
        {
            contentcontrol.Content = new PropertyValue<object>(contentFunc);
            return contentcontrol;
        }
        public static T ContentTransitions<T>(this T contentcontrol, TransitionCollection contentTransitions) where T : IRxContentControl
        {
            contentcontrol.ContentTransitions = new PropertyValue<TransitionCollection>(contentTransitions);
            return contentcontrol;
        }
        public static T ContentTransitions<T>(this T contentcontrol, Func<TransitionCollection> contentTransitionsFunc) where T : IRxContentControl
        {
            contentcontrol.ContentTransitions = new PropertyValue<TransitionCollection>(contentTransitionsFunc);
            return contentcontrol;
        }
    }
}
