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
    public partial interface IRxCanvas : IRxPanel
    {

    }

    public partial class RxCanvas<T> : RxPanel<T>, IRxCanvas where T : Canvas, new()
    {
        public RxCanvas()
        {

        }

        public RxCanvas(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxCanvas = (IRxCanvas)this;

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxCanvas = (IRxCanvas)this;

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
    public partial class RxCanvas : RxCanvas<Canvas>
    {
        public RxCanvas()
        {

        }

        public RxCanvas(Action<Canvas> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxCanvasExtensions
    {
    }
}
