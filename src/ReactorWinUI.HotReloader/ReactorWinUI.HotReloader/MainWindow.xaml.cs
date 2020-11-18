using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ReactorWinUI.HotReloader
{
    [ComImport, System.Runtime.InteropServices.Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInitializeWithWindow
    {
        void Initialize([In] IntPtr hwnd);
    }


    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto, PreserveSig = true, SetLastError = false)]
        public static extern IntPtr GetActiveWindow();        
        
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //var picker = new Windows.Storage.Pickers.FileOpenPicker();
            ////picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            ////picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            //picker.FileTypeFilter.Add(".dll");
            //if (Window.Current == null)
            //{
            //    IInitializeWithWindow initializeWithWindowWrapper = Windows.Storage.Pickers.FileOpenPicker.As<IInitializeWithWindow>();
            //    IntPtr hwnd = GetActiveWindow();
            //    initializeWithWindowWrapper.Initialize(hwnd);
            //}
            //Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            //if (file != null)
            //{
            //    RxApplication.Create(file.Path).Run();
            //}

        }
    }
}
