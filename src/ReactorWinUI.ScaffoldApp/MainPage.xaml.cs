using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReactorWinUI.ScaffoldApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var listOfElements = (
                    from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                        // alternative: from domainAssembly in domainAssembly.GetExportedTypes()
                    from assemblyType in domainAssembly.GetTypes()
                    where assemblyType == typeof(UIElement) || typeof(UIElement).IsAssignableFrom(assemblyType)
                    // alternative: where assemblyType.IsSubclassOf(typeof(B))
                    // alternative: && ! assemblyType.IsAbstract
                    select assemblyType)
                    .OrderBy(_ => _.FullName)
                    .Select(_ => new TypeModel(_))
                    .ToList();

            lstTypes.ItemsSource = listOfElements;

            File.ReadAllLines("WidgetList.txt")
                .Select(_ => listOfElements.First(t => t.FullName == _))
                .ToList()
                .ForEach(_ => lstTypes.SelectedItems.Add(_));
        }

        private void OnSelectAll(object sender, RoutedEventArgs e)
        {
            lstTypes.SelectAll();
        }

        private async void OnGenerate(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker
            {
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop
            };
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                    FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                foreach (var typeToGenerate in lstTypes.SelectedItems.Cast<TypeModel>())
                {
                    //var targetPath = Path.Combine(folder.Path, $"Rx{typeToGenerate.Name}.cs");
                    //Console.WriteLine($"Generating {typeToGenerate.FullName} to {targetPath}...");

                    var generator = new TypeSourceGenerator(typeToGenerate.Type);
                    //File.WriteAllText(targetPath, generator.TransformAndPrettify());
                    Windows.Storage.StorageFile targetFile =
                        await folder.CreateFileAsync($"Rx{typeToGenerate.Type.Name}.cs", Windows.Storage.CreationCollisionOption.ReplaceExisting);
                    await Windows.Storage.FileIO.WriteTextAsync(targetFile, generator.TransformAndPrettify());
                }
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = lstTypes.SelectedItem as TypeModel;
            var generator = new TypeSourceGenerator(selectedType.Type);
            tbSourceCode.Text = generator.TransformAndPrettify();
        }
    }

    public class TypeModel
    {
        public TypeModel(Type type)
        {
            Type = type;
        }

        public string FullName =>
            Type.FullName;

        public Type Type { get; }
    }
}
