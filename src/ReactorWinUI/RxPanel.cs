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
    public partial interface IRxPanel : IRxFrameworkElement
    {
        PropertyValue<Brush> Background { get; set; }
        PropertyValue<TransitionCollection> ChildrenTransitions { get; set; }

    }

    public partial class RxPanel<T> : RxFrameworkElement<T>, IRxPanel where T : Panel, new()
    {
        public RxPanel()
        {

        }

        public RxPanel(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<Brush> IRxPanel.Background { get; set; }
        PropertyValue<TransitionCollection> IRxPanel.ChildrenTransitions { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxPanel = (IRxPanel)this;
            NativeControl.Set(this, Panel.BackgroundProperty, thisAsIRxPanel.Background);
            NativeControl.Set(this, Panel.ChildrenTransitionsProperty, thisAsIRxPanel.ChildrenTransitions);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxPanel = (IRxPanel)this;

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
    public static partial class RxPanelExtensions
    {
        public static T Background<T>(this T panel, Brush background) where T : IRxPanel
        {
            panel.Background = new PropertyValue<Brush>(background);
            return panel;
        }
        public static T ChildrenTransitions<T>(this T panel, TransitionCollection childrenTransitions) where T : IRxPanel
        {
            panel.ChildrenTransitions = new PropertyValue<TransitionCollection>(childrenTransitions);
            return panel;
        }
    }
}
