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
    public partial interface IRxFrame : IRxContentControl
    {
        PropertyValue<int> CacheSize { get; set; }
        PropertyValue<bool> IsNavigationStackEnabled { get; set; }
        PropertyValue<Type> SourcePageType { get; set; }

    }

    public partial class RxFrame<T> : RxContentControl<T>, IRxFrame where T : Frame, new()
    {
        public RxFrame()
        {

        }

        public RxFrame(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<int> IRxFrame.CacheSize { get; set; }
        PropertyValue<bool> IRxFrame.IsNavigationStackEnabled { get; set; }
        PropertyValue<Type> IRxFrame.SourcePageType { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxFrame = (IRxFrame)this;
            SetPropertyValue(NativeControl, Frame.CacheSizeProperty, thisAsIRxFrame.CacheSize);
            SetPropertyValue(NativeControl, Frame.IsNavigationStackEnabledProperty, thisAsIRxFrame.IsNavigationStackEnabled);
            SetPropertyValue(NativeControl, Frame.SourcePageTypeProperty, thisAsIRxFrame.SourcePageType);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxFrame = (IRxFrame)this;

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
    public partial class RxFrame : RxFrame<Frame>
    {
        public RxFrame()
        {

        }

        public RxFrame(Action<Frame> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxFrameExtensions
    {
        public static T CacheSize<T>(this T frame, int cacheSize) where T : IRxFrame
        {
            frame.CacheSize = new PropertyValue<int>(cacheSize);
            return frame;
        }
        public static T CacheSize<T>(this T frame, Func<int> cacheSizeFunc) where T : IRxFrame
        {
            frame.CacheSize = new PropertyValue<int>(cacheSizeFunc);
            return frame;
        }
        public static T IsNavigationStackEnabled<T>(this T frame, bool isNavigationStackEnabled) where T : IRxFrame
        {
            frame.IsNavigationStackEnabled = new PropertyValue<bool>(isNavigationStackEnabled);
            return frame;
        }
        public static T IsNavigationStackEnabled<T>(this T frame, Func<bool> isNavigationStackEnabledFunc) where T : IRxFrame
        {
            frame.IsNavigationStackEnabled = new PropertyValue<bool>(isNavigationStackEnabledFunc);
            return frame;
        }
        public static T SourcePageType<T>(this T frame, Type sourcePageType) where T : IRxFrame
        {
            frame.SourcePageType = new PropertyValue<Type>(sourcePageType);
            return frame;
        }
        public static T SourcePageType<T>(this T frame, Func<Type> sourcePageTypeFunc) where T : IRxFrame
        {
            frame.SourcePageType = new PropertyValue<Type>(sourcePageTypeFunc);
            return frame;
        }
    }
}
