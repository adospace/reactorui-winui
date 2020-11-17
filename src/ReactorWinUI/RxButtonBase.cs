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
    public partial interface IRxButtonBase : IRxContentControl
    {
        PropertyValue<ClickMode> ClickMode { get; set; }

        Action ClickAction { get; set; }
        Action<object, RoutedEventArgs> ClickActionWithArgs { get; set; }
    }

    public partial class RxButtonBase<T> : RxContentControl<T>, IRxButtonBase where T : ButtonBase, new()
    {
        public RxButtonBase()
        {

        }

        public RxButtonBase(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<ClickMode> IRxButtonBase.ClickMode { get; set; }

        Action IRxButtonBase.ClickAction { get; set; }
        Action<object, RoutedEventArgs> IRxButtonBase.ClickActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxButtonBase = (IRxButtonBase)this;
            NativeControl.Set(this, ButtonBase.ClickModeProperty, thisAsIRxButtonBase.ClickMode);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxButtonBase = (IRxButtonBase)this;
            if (thisAsIRxButtonBase.ClickAction != null || thisAsIRxButtonBase.ClickActionWithArgs != null)
            {
                NativeControl.Click += NativeControl_Click;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Click(object sender, RoutedEventArgs e)
        {
            var thisAsIRxButtonBase = (IRxButtonBase)this;
            thisAsIRxButtonBase.ClickAction?.Invoke();
            thisAsIRxButtonBase.ClickActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.Click -= NativeControl_Click;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxButtonBaseExtensions
    {
        public static T ClickMode<T>(this T buttonbase, ClickMode clickMode) where T : IRxButtonBase
        {
            buttonbase.ClickMode = new PropertyValue<ClickMode>(clickMode);
            return buttonbase;
        }
        public static T OnClick<T>(this T buttonbase, Action clickAction) where T : IRxButtonBase
        {
            buttonbase.ClickAction = clickAction;
            return buttonbase;
        }

        public static T OnClick<T>(this T buttonbase, Action<object, RoutedEventArgs> clickActionWithArgs) where T : IRxButtonBase
        {
            buttonbase.ClickActionWithArgs = clickActionWithArgs;
            return buttonbase;
        }
    }
}
