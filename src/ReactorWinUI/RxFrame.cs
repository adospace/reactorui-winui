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
            NativeControl.Set(this, Frame.CacheSizeProperty, thisAsIRxFrame.CacheSize);
            NativeControl.Set(this, Frame.IsNavigationStackEnabledProperty, thisAsIRxFrame.IsNavigationStackEnabled);
            NativeControl.Set(this, Frame.SourcePageTypeProperty, thisAsIRxFrame.SourcePageType);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxFrame = (IRxFrame)this;

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
        public static T IsNavigationStackEnabled<T>(this T frame, bool isNavigationStackEnabled) where T : IRxFrame
        {
            frame.IsNavigationStackEnabled = new PropertyValue<bool>(isNavigationStackEnabled);
            return frame;
        }
        public static T SourcePageType<T>(this T frame, Type sourcePageType) where T : IRxFrame
        {
            frame.SourcePageType = new PropertyValue<Type>(sourcePageType);
            return frame;
        }
    }
}
