using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorWinUI.DemoApp
{
    [EntryComponent]
    public class MainComponent : RxComponent
    {
        public override VisualNode Render()
        {
            return new RxTextBlock()
                .Text("Hello World")
                .FontSize(32)
                .VCenter()
                .HCenter();
        }
    }
}
