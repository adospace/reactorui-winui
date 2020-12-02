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
using System.Linq;

namespace ReactorWinUI
{
    public partial interface IRxSelector : IRxItemsControl
    {
        Action<object, SelectionChangedEventArgs> SelectionChangedActionWithArgs { get; set; }
    }

    public partial class RxSelector<T>
    {
        Action<object, SelectionChangedEventArgs> IRxSelector.SelectionChangedActionWithArgs { get; set; }


        partial void OnBeginAttachNativeEvents()
        {
            var thisAsIRxSelector = (IRxSelector)this;
            if (thisAsIRxSelector.SelectionChangedActionWithArgs != null)
            {
                NativeControl.SelectionChanged += NativeControl_SelectionChanged;
            }
        }

        private void NativeControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var thisAsIRxSelector = (IRxSelector)this;
            thisAsIRxSelector.SelectionChangedActionWithArgs?.Invoke(sender, e);
        }

        partial void OnBeginDetachNativeEvents()
        {
            var thisAsIRxSelector = (IRxSelector)this;
            if (thisAsIRxSelector.SelectionChangedActionWithArgs != null)
            {
                NativeControl.SelectionChanged -= NativeControl_SelectionChanged;
            }
        }

    }

    public partial class RxSelectorExtensions
    {
        public static T OnSelectionChanged<T>(this T itemscontrol, Action<object, SelectionChangedEventArgs> selectedChangedAction) where T : IRxSelector
        {
            itemscontrol.SelectionChangedActionWithArgs = selectedChangedAction;

            return itemscontrol;
        }

        public static T OnSelectionChanged<T, I>(this T itemscontrol, Action<I[], I[]> selectedChangedAction) where T : IRxSelector
        {
            itemscontrol.SelectionChangedActionWithArgs = (sender, args) => selectedChangedAction(args.AddedItems.Cast<I>().ToArray(), args.RemovedItems.Cast<I>().ToArray());

            return itemscontrol;
        }

        public static T OnSelectedItemChanged<T, I>(this T itemscontrol, Action<I> selectedChangedAction) where T : IRxSelector
        {
            itemscontrol.SelectionChangedActionWithArgs = (sender, args) => selectedChangedAction((I)((Selector)sender).SelectedItem);

            return itemscontrol;
        }
    }
}
