using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactorWinUI.Internals
{
    internal class AssemblyFileComponentLoader : IComponentLoader
    {
        private readonly string _assemblyFileName;
        private FileSystemWatcher _fileSystemWatcher;

        public AssemblyFileComponentLoader(string assemblyFileName)
        {
            if (string.IsNullOrWhiteSpace(assemblyFileName))
            {
                throw new ArgumentException($"'{nameof(assemblyFileName)}' can't be null or empty", nameof(assemblyFileName));
            }

            _assemblyFileName = Path.GetFullPath(assemblyFileName);
        }

        public event EventHandler ComponentAssemblyChanged;

        public RxComponent LoadComponent(string componentTypeFullName)
        {
            var assemblyPath = _assemblyFileName;
            var assemblyPdbPath = Path.Combine(Path.GetDirectoryName(assemblyPath), Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            Assembly assembly = null;
            int retries = 5;
            while (retries > 0)
            {
                retries--;

                try
                {
                    assembly = File.Exists(assemblyPdbPath) ?
                         Assembly.Load(File.ReadAllBytes(assemblyPath))
                         :
                         Assembly.Load(File.ReadAllBytes(assemblyPath), File.ReadAllBytes(assemblyPdbPath));
                    break;
                }
                catch (System.IO.IOException)
                {
                    Thread.Sleep(100);
                }
            }

            if (assembly == null)
                return null;

            var type = assembly.GetType(componentTypeFullName);

            return (RxComponent)Activator.CreateInstance(type);
        }

        public void Run()
        {
            _fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(_assemblyFileName), "*" + Path.GetExtension(_assemblyFileName));
            _fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite;

            _fileSystemWatcher.Changed += OnAssemblyFileChanged;

            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void OnAssemblyFileChanged(object sender, FileSystemEventArgs e)
        {
            if (Path.GetFullPath(e.FullPath) != Path.GetFullPath(_assemblyFileName))
                return;

            _fileSystemWatcher.EnableRaisingEvents = false;

            try
            {
                ComponentAssemblyChanged?.Invoke(this, EventArgs.Empty);
            }
            finally
            {
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        public void Stop()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
            _fileSystemWatcher.Changed -= OnAssemblyFileChanged;
            _fileSystemWatcher.Dispose();
        }
    }
}