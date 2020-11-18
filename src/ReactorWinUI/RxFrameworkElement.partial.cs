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
    public static partial class RxFrameworkElementExtensions
    {
        public static T HLeft<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(Microsoft.UI.Xaml.HorizontalAlignment.Left);
            return layoutable;
        }

        public static T HCenter<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(Microsoft.UI.Xaml.HorizontalAlignment.Center);
            return layoutable;
        }

        public static T HRight<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(Microsoft.UI.Xaml.HorizontalAlignment.Right);
            return layoutable;
        }

        public static T HStretch<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(Microsoft.UI.Xaml.HorizontalAlignment.Stretch);
            return layoutable;
        }

        public static T VTop<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(Microsoft.UI.Xaml.VerticalAlignment.Top);
            return layoutable;
        }

        public static T VCenter<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(Microsoft.UI.Xaml.VerticalAlignment.Center);
            return layoutable;
        }

        public static T VBottom<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(Microsoft.UI.Xaml.VerticalAlignment.Bottom);
            return layoutable;
        }

        public static T VStretch<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(Microsoft.UI.Xaml.VerticalAlignment.Stretch);
            return layoutable;
        }
    }
}
