using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

using ReactorWinUI.Internals;
using Microsoft.UI.Xaml;

namespace ReactorWinUI
{
    public interface IRxApplicationHost
    {
        void SetRoot(UIElement rootElement);
    }

    public class RxApplication : VisualNode, IRxHostElement
    {
        public static RxApplication Instance { get; private set; }
        //private readonly Application _application;
        private readonly Type _rootComponentType;
        private readonly IRxApplicationHost _applicationHost;
        private RxComponent _rootComponent;
        private bool _sleeping = true;
        private readonly DispatcherTimer _animationTimer = null;
        private UIElement _rootElement;
        private Window _mainWindow;

        private RxApplication(Type rootComponentType, IRxApplicationHost applicationHost = null)
        {
            if (Instance != null)
            {
                throw new InvalidOperationException("Only one instance of RxApplication is permitted");
            }

            Instance = this;

            //_application = application ?? throw new ArgumentNullException(nameof(application));
            _rootComponentType = rootComponentType;
            _applicationHost = applicationHost;
            _animationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16)
            };
            _animationTimer.Tick += (s, e) =>
            {
                Animate();
                if (!IsAnimationFrameRequested)
                {
                    _animationTimer.Stop();
                }
            };

        }

        public Action<System.UnhandledExceptionEventArgs> UnhandledException { get; set; }

        internal void FireUnhandledExpectionEvent(Exception ex)
        {
            UnhandledException?.Invoke(new System.UnhandledExceptionEventArgs(ex, false));
            System.Diagnostics.Debug.WriteLine(ex);
        }

        public static RxApplication Create<T>(IRxApplicationHost applicationHost = null) where T : RxComponent, new()
            => new RxApplication(typeof(T), applicationHost);

        //public static RxApplication Create(IRxApplicationHost applicationHost = null)
        //{
        //    var componentType = AppDomain.CurrentDomain.GetAssemblies()
        //        .SelectMany(_ => _.GetTypes())
        //        .First(_ => _.GetCustomAttribute(typeof(EntryComponentAttribute)) != null);

        //    return new RxApplication(componentType, applicationHost);
        //}

        public static RxApplication Create(string assemblyPath)
        {
            var assemblyPdbPath = Path.Combine(Path.GetDirectoryName(assemblyPath), Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            var assembly = File.Exists(assemblyPdbPath) ?
                Assembly.Load(File.ReadAllBytes(assemblyPath))
                :
                Assembly.Load(File.ReadAllBytes(assemblyPath), File.ReadAllBytes(assemblyPdbPath));

            ComponentLoader.Instance = new AssemblyFileComponentLoader(assemblyPath);

            string folderPath = Path.GetDirectoryName(assemblyPath);

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += (object sender, ResolveEventArgs args) =>
            {
                string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
                if (!File.Exists(assemblyPath)) return null;
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                return assembly;
            };

            var componentType = assembly.GetTypes().First(_ => _.GetCustomAttribute(typeof(EntryComponentAttribute)) != null);

            return new RxApplication(componentType);
        }

        public RxApplication WithContext(string key, object value)
        {
            Context[key] = value;
            return this;
        }

        public RxApplication OnUnhandledException(Action<System.UnhandledExceptionEventArgs> action)
        {
            UnhandledException = action;
            return this;
        }

        public RxContext Context { get; } = new RxContext();

        public Window ContainerWindow
        {
            get
            {
                return Window.Current;
            }
        }

        protected sealed override void OnAddChild(VisualNode widget, DependencyObject nativeControl)
        {
            if (nativeControl is UIElement rootElement)
            {
                _rootElement = rootElement;
                if (_applicationHost != null)
                {
                    _applicationHost.SetRoot(rootElement);
                }
                else if (_mainWindow != null)
                {
                    _mainWindow.Content = rootElement;
                }
                else if (Window.Current != null)
                {
                    Window.Current.Content = rootElement;
                }
                    
            }
            else
            {
                throw new NotSupportedException($"Invalid root component ({nativeControl.GetType()}): must be a window (i.e. RxWindow)");
            }
        }

        protected sealed override void OnRemoveChild(VisualNode widget, DependencyObject nativeControl)
        {
            //_application.MainWindow?.Close();
        }

        public void SafeInvoke(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (_mainWindow != null)
            {
                if (_mainWindow.Dispatcher != null && !_mainWindow.Dispatcher.HasThreadAccess)
                {
                    _mainWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(action)).AsTask().Wait();
                }
                else
                {
                    action();
                    return;
                }
            }

            if (Window.Current != null)
            {
                if (!Window.Current.Dispatcher.HasThreadAccess)
                {
                    Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(action)).AsTask().Wait();
                }
                else
                {
                    action();
                    return;
                }
            }

            if (_rootElement == null)
            {
                throw new InvalidOperationException();
            }

            if (!_rootElement.Dispatcher.HasThreadAccess)
            {
                _rootElement.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, new Windows.UI.Core.DispatchedHandler(action)).AsTask().Wait();
            }
            else
            {
                action();
            }
        }

        public IRxHostElement Run()
        {
            if (Window.Current == null)
            {
                _mainWindow = new Window();
            }

            if (_sleeping)
            {

                if (_rootComponent == null)
                {
                    if (ComponentLoader.Instance != null)
                    {
                        _rootComponent = ComponentLoader.Instance.LoadComponent(_rootComponentType.FullName);
                    }
                    else
                    {
                        _rootComponent = (RxComponent)Activator.CreateInstance(_rootComponentType);
                    }
                }

                _sleeping = false;
                
                OnLayout();

                if (ComponentLoader.Instance != null)
                {
                    ComponentLoader.Instance.ComponentAssemblyChanged += OnComponentAssemblyChanged;
                    ComponentLoader.Instance.Run();
                }
            }

            if (Window.Current != null)
            {
                Window.Current.Activate();
            }
            else
            {
                _mainWindow.Activate();
            }

            return this;
        }

        private async void OnComponentAssemblyChanged(object sender, EventArgs e)
        {
            if (_rootElement == null)
            {
                throw new InvalidOperationException();
            }

            if (!_rootElement.Dispatcher.HasThreadAccess)
            {
                await _rootElement.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => OnComponentAssemblyChanged(sender, e)).AsTask();
                return;
            }

            try
            {
                var newComponent = ComponentLoader.Instance.LoadComponent(_rootComponentType.FullName);

                if (newComponent != null)
                {
                    _rootComponent = newComponent;
                    Invalidate();
                }
            }
            catch (Exception ex)
            {
                FireUnhandledExpectionEvent(ex);
            }
        }

        public void Stop()
        {
            if (!_sleeping)
            {
                _sleeping = true;

                if (ComponentLoader.Instance != null)
                {
                    ComponentLoader.Instance.ComponentAssemblyChanged -= OnComponentAssemblyChanged;
                    ComponentLoader.Instance.Stop();
                }
            }
        }

        protected internal override void OnLayoutCycleRequested()
        {
            if (!_sleeping)
            {
                SafeInvoke(OnLayout);
            }

            base.OnLayoutCycleRequested();
        }

        private void OnLayout()
        {
            try
            {
                Layout();

                //_animationTimer.IsEnabled = IsAnimationFrameRequested;
                if (IsAnimationFrameRequested && !_animationTimer.IsEnabled)
                    _animationTimer.Start();
                else if (!IsAnimationFrameRequested && _animationTimer.IsEnabled)
                    _animationTimer.Stop();
            }
            catch (Exception ex)
            {
                FireUnhandledExpectionEvent(ex);
            }
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield return _rootComponent;
        }


    }
}