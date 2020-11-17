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
            NativeControl.Set(this, Page.BottomAppBarProperty, thisAsIRxPage.BottomAppBar);
            NativeControl.Set(this, Page.TopAppBarProperty, thisAsIRxPage.TopAppBar);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxPage = (IRxPage)this;

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
        public static T TopAppBar<T>(this T page, AppBar topAppBar) where T : IRxPage
        {
            page.TopAppBar = new PropertyValue<AppBar>(topAppBar);
            return page;
        }
    }
}
