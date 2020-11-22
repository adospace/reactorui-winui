using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Web.WebView2.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ReactorWinUI.HotReloader
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private IRxHostElement _rxApp;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            //Log.Information($"commmand line: {args.Arguments}");

            //var assemblyPath = args.Arguments;

            //if (string.IsNullOrEmpty(args.Arguments))
            //{
            //    var commandLineArgsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CommandLineArgs.txt");
            //    if (File.Exists(commandLineArgsPath))
            //    {
            //        assemblyPath = File.ReadAllText(commandLineArgsPath);
            //    }
            //}

            //if (string.IsNullOrEmpty(assemblyPath))
            //{
            //    assemblyPath = @"..\..\..\..\..\..\..\ReactorWinUI.DemoApp\bin\Debug\net5.0-windows10.0.18362.0\ReactorWinUI.DemoApp.dll"; 
            //    // @"C:\Users\adosp\source\repos\reactorui-winui\src\ReactorWinUI.DemoApp\bin\Debug\net5.0-windows10.0.18362.0\ReactorWinUI.DemoApp.dll";
            //    //               
            //}

            var commandLineArgs = Environment.GetCommandLineArgs();

            if (commandLineArgs == null ||
                commandLineArgs.Length < 2)
            {
                throw new InvalidOperationException("Pass the path to the ReactorUI application (dll) in command line");
            }

            var assemblyPath = commandLineArgs[1];

            _rxApp = RxApplication.Create(assemblyPath).Run();

            //var window = new Window();
            //window.Activate();

            //m_window = new MainWindow();
            //m_window.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            // Save application state and stop any background activity
            _rxApp.Stop();
        }

        //private Window m_window;
    }
}
