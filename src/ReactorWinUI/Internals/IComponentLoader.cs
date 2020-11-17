using System;

namespace ReactorWinUI.Internals
{
    internal interface IComponentLoader
    {
        RxComponent LoadComponent(string componentTypeFullName);

        event EventHandler ComponentAssemblyChanged;

        void Run();

        void Stop();
    }

    internal static class ComponentLoader
    {
        static IComponentLoader _instance;
        public static IComponentLoader Instance
        {
            get => _instance;
            set
            {
                if (_instance != null)
                    throw new InvalidOperationException();
                
                _instance = value;
            }
        }

    }
}