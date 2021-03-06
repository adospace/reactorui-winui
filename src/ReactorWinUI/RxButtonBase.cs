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
            SetPropertyValue(NativeControl, ButtonBase.ClickModeProperty, thisAsIRxButtonBase.ClickMode);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxButtonBase = (IRxButtonBase)this;
            if (thisAsIRxButtonBase.ClickAction != null || thisAsIRxButtonBase.ClickActionWithArgs != null)
            {
                NativeControl.Click += NativeControl_Click;
            }

            base.OnAttachNativeEvents();

            OnEndAttachNativeEvents();
        }

        private void NativeControl_Click(object sender, RoutedEventArgs e)
        {
            var thisAsIRxButtonBase = (IRxButtonBase)this;
            thisAsIRxButtonBase.ClickAction?.Invoke();
            thisAsIRxButtonBase.ClickActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnBeginDetachNativeEvents();

            if (NativeControl != null)
            {
                NativeControl.Click -= NativeControl_Click;
            }

            base.OnDetachNativeEvents();

            OnEndDetachNativeEvents();
        }

        partial void OnBeginAttachNativeEvents();
        partial void OnEndAttachNativeEvents();
        partial void OnBeginDetachNativeEvents();
        partial void OnEndDetachNativeEvents();
    }
    public static partial class RxButtonBaseExtensions
    {
        public static T ClickMode<T>(this T buttonbase, ClickMode clickMode) where T : IRxButtonBase
        {
            buttonbase.ClickMode = new PropertyValue<ClickMode>(clickMode);
            return buttonbase;
        }
        public static T ClickMode<T>(this T buttonbase, Func<ClickMode> clickModeFunc) where T : IRxButtonBase
        {
            buttonbase.ClickMode = new PropertyValue<ClickMode>(clickModeFunc);
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
