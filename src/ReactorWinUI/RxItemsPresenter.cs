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
    public partial interface IRxItemsPresenter : IRxFrameworkElement
    {
        PropertyValue<object> Footer { get; set; }
        PropertyValue<TransitionCollection> FooterTransitions { get; set; }
        PropertyValue<object> Header { get; set; }
        PropertyValue<TransitionCollection> HeaderTransitions { get; set; }
        PropertyValue<Thickness> Padding { get; set; }

    }

    public partial class RxItemsPresenter : RxFrameworkElement<ItemsPresenter>, IRxItemsPresenter
    {
        public RxItemsPresenter()
        {

        }

        public RxItemsPresenter(Action<ItemsPresenter> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<object> IRxItemsPresenter.Footer { get; set; }
        PropertyValue<TransitionCollection> IRxItemsPresenter.FooterTransitions { get; set; }
        PropertyValue<object> IRxItemsPresenter.Header { get; set; }
        PropertyValue<TransitionCollection> IRxItemsPresenter.HeaderTransitions { get; set; }
        PropertyValue<Thickness> IRxItemsPresenter.Padding { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxItemsPresenter = (IRxItemsPresenter)this;
            SetPropertyValue(NativeControl, ItemsPresenter.FooterProperty, thisAsIRxItemsPresenter.Footer);
            SetPropertyValue(NativeControl, ItemsPresenter.FooterTransitionsProperty, thisAsIRxItemsPresenter.FooterTransitions);
            SetPropertyValue(NativeControl, ItemsPresenter.HeaderProperty, thisAsIRxItemsPresenter.Header);
            SetPropertyValue(NativeControl, ItemsPresenter.HeaderTransitionsProperty, thisAsIRxItemsPresenter.HeaderTransitions);
            SetPropertyValue(NativeControl, ItemsPresenter.PaddingProperty, thisAsIRxItemsPresenter.Padding);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxItemsPresenter = (IRxItemsPresenter)this;

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
    public static partial class RxItemsPresenterExtensions
    {
        public static T Footer<T>(this T itemspresenter, object footer) where T : IRxItemsPresenter
        {
            itemspresenter.Footer = new PropertyValue<object>(footer);
            return itemspresenter;
        }
        public static T Footer<T>(this T itemspresenter, Func<object> footerFunc) where T : IRxItemsPresenter
        {
            itemspresenter.Footer = new PropertyValue<object>(footerFunc);
            return itemspresenter;
        }
        public static T FooterTransitions<T>(this T itemspresenter, TransitionCollection footerTransitions) where T : IRxItemsPresenter
        {
            itemspresenter.FooterTransitions = new PropertyValue<TransitionCollection>(footerTransitions);
            return itemspresenter;
        }
        public static T FooterTransitions<T>(this T itemspresenter, Func<TransitionCollection> footerTransitionsFunc) where T : IRxItemsPresenter
        {
            itemspresenter.FooterTransitions = new PropertyValue<TransitionCollection>(footerTransitionsFunc);
            return itemspresenter;
        }
        public static T Header<T>(this T itemspresenter, object header) where T : IRxItemsPresenter
        {
            itemspresenter.Header = new PropertyValue<object>(header);
            return itemspresenter;
        }
        public static T Header<T>(this T itemspresenter, Func<object> headerFunc) where T : IRxItemsPresenter
        {
            itemspresenter.Header = new PropertyValue<object>(headerFunc);
            return itemspresenter;
        }
        public static T HeaderTransitions<T>(this T itemspresenter, TransitionCollection headerTransitions) where T : IRxItemsPresenter
        {
            itemspresenter.HeaderTransitions = new PropertyValue<TransitionCollection>(headerTransitions);
            return itemspresenter;
        }
        public static T HeaderTransitions<T>(this T itemspresenter, Func<TransitionCollection> headerTransitionsFunc) where T : IRxItemsPresenter
        {
            itemspresenter.HeaderTransitions = new PropertyValue<TransitionCollection>(headerTransitionsFunc);
            return itemspresenter;
        }
        public static T Padding<T>(this T itemspresenter, Thickness padding) where T : IRxItemsPresenter
        {
            itemspresenter.Padding = new PropertyValue<Thickness>(padding);
            return itemspresenter;
        }
        public static T Padding<T>(this T itemspresenter, Func<Thickness> paddingFunc) where T : IRxItemsPresenter
        {
            itemspresenter.Padding = new PropertyValue<Thickness>(paddingFunc);
            return itemspresenter;
        }
        public static T Padding<T>(this T itemspresenter, double leftRight, double topBottom) where T : IRxItemsPresenter
        {
            itemspresenter.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return itemspresenter;
        }
        public static T Padding<T>(this T itemspresenter, double uniformSize) where T : IRxItemsPresenter
        {
            itemspresenter.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return itemspresenter;
        }
    }
}
