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
    public partial interface IRxPage : IRxUserControl
    {
        PropertyValue<AppBar> BottomAppBar { get; set; }
        PropertyValue<AppBar> TopAppBar { get; set; }

    }

    public partial class RxPage<T> : RxUserControl<T>, IRxPage where T : Page, new()
    {
        public RxPage()
        {

        }

        public RxPage(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }
        PropertyValue<AppBar> IRxPage.BottomAppBar { get; set; }
        PropertyValue<AppBar> IRxPage.TopAppBar { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxPage = (IRxPage)this;
            SetPropertyValue(NativeControl, Page.BottomAppBarProperty, thisAsIRxPage.BottomAppBar);
            SetPropertyValue(NativeControl, Page.TopAppBarProperty, thisAsIRxPage.TopAppBar);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            OnBeginAttachNativeEvents();

            var thisAsIRxPage = (IRxPage)this;

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
    public partial class RxPage : RxPage<Page>
    {
        public RxPage()
        {

        }

        public RxPage(Action<Page> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxPageExtensions
    {
        public static T BottomAppBar<T>(this T page, AppBar bottomAppBar) where T : IRxPage
        {
            page.BottomAppBar = new PropertyValue<AppBar>(bottomAppBar);
            return page;
        }
        public static T BottomAppBar<T>(this T page, Func<AppBar> bottomAppBarFunc) where T : IRxPage
        {
            page.BottomAppBar = new PropertyValue<AppBar>(bottomAppBarFunc);
            return page;
        }
        public static T TopAppBar<T>(this T page, AppBar topAppBar) where T : IRxPage
        {
            page.TopAppBar = new PropertyValue<AppBar>(topAppBar);
            return page;
        }
        public static T TopAppBar<T>(this T page, Func<AppBar> topAppBarFunc) where T : IRxPage
        {
            page.TopAppBar = new PropertyValue<AppBar>(topAppBarFunc);
            return page;
        }
    }
}
