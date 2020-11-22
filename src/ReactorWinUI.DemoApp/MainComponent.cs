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
            return new RxWindow()
            {
                new RxGrid("Auto", "* 2.5*")
                {
                    new RxTextBlock()
                        .Text("Hello"),
                    new RxTextBlock()
                        .Text("World")
                        .GridColumn(1)
                }
                .VCenter()
            };
        }
    }
}
