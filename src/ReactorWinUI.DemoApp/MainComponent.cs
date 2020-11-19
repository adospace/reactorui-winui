using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorWinUI.DemoApp
{
    public class MainComponent : RxComponent
    {
        public override VisualNode Render()
        {
            return new RxStackPanel()
            {
                new RxTextBlock()
                    .Text("Hello"),
                new RxTextBlock()
                    .Text("World")
            }
            .VCenter()
            .HCenter();
        }
    }
}
