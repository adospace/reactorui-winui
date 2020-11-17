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

using ReactorWinUI.Internals;
using Windows.UI.Xaml.Navigation;

namespace ReactorWinUI
{
    public partial class RxFrame : INavigation
    {
        public bool CanGoBack => (NativeControl ?? throw new InvalidOperationException()).CanGoBack;

        public bool CanGoForward => (NativeControl ?? throw new InvalidOperationException()).CanGoForward;

        public int BackStackDepth => (NativeControl ?? throw new InvalidOperationException()).BackStackDepth;

        protected override void OnAddChildCore(VisualNode widget, DependencyObject childControl)
        {
            
        }

        protected override void OnRemoveChildCore(VisualNode widget, DependencyObject childControl)
        {            
        }

        protected override TChild OnCreatChild<TChild>()
        {
            if (typeof(Page).IsAssignableFrom(typeof(TChild)))
            {
                return Navigate<TChild>();
            }

            throw new InvalidOperationException();
        }

        private TPage Navigate<TPage>(
            NavigationTransitionInfo transitionInfo = null)
            where TPage : class
        {
            TPage view = null;
            void OnNavigated(object s, NavigationEventArgs args)
            {
                NativeControl.Navigated -= OnNavigated;
                view = args.Content as TPage;
            }

            NativeControl.Navigated += OnNavigated;

            NativeControl.Navigate(typeof(TPage), null, transitionInfo);
            return view;
        }

        public void GoBack() => (NativeControl ?? throw new InvalidOperationException()).GoBack();

        public void GoForward() => (NativeControl ?? throw new InvalidOperationException()).GoForward();
    }
}
