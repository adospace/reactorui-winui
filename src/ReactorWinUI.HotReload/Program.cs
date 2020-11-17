using ReactorWinUI.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ReactorWinUI.HotReload
{
    public class Program
    {
        [System.STAThreadAttribute()]
        public static void Main(string[] args)
        {
            if (args == null ||
                args.Length == 0)
            {
                Console.WriteLine("Specify the assembly path to load");
                return;
            }

            var assemblyPath = args[0];

            if (!Path.IsPathRooted(assemblyPath))
            {
                assemblyPath = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), assemblyPath);
            }

            if (!File.Exists(assemblyPath))
            {
                Console.WriteLine($"The assembly '{assemblyPath}' doesn't exist");
                return;
            }

            var assemblyPdbPath = Path.Combine(Path.GetDirectoryName(assemblyPath), Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            var assembly = File.Exists(assemblyPdbPath) ?
                Assembly.Load(File.ReadAllBytes(assemblyPath))
                :
                Assembly.Load(File.ReadAllBytes(assemblyPath), File.ReadAllBytes(assemblyPdbPath));

            ComponentLoader.Instance = new AssemblyFileComponentLoader(assemblyPath);

            AppDomain currentDomain = AppDomain.CurrentDomain;
            string folderPath = Path.GetDirectoryName(assemblyPath);

            currentDomain.AssemblyResolve += (object sender, ResolveEventArgs args) =>
            {
                string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
                if (!File.Exists(assemblyPath)) return null;
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                return assembly;
            };

            using (new ReactorWinUI.Host.App())
            {
                var app = new App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
}
