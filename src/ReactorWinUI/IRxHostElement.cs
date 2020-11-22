
using System.Windows;
using Microsoft.UI.Xaml;

namespace ReactorWinUI
{
    public interface IRxHostElement
    {
        IRxHostElement Run();

        void Stop();

        //Window ContainerWindow { get; }
    }
}