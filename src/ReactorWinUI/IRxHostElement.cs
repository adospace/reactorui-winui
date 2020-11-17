
using System.Windows;
using Windows.UI.Xaml;

namespace ReactorWinUI
{
    public interface IRxHostElement
    {
        IRxHostElement Run();

        void Stop();

        Window ContainerWindow { get; }
    }
}