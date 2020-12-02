using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorWinUI.DemoApp
{
    public class CounterComponentState : IState 
    {
        public int Counter { get; set; }
    }

    public class CounterComponent : RxComponent<CounterComponentState>
    {
        public override VisualNode Render()
        {
            return new RxStackPanel()
            {
                new RxTextBlock()
                    .Text(()=>State.Counter.ToString())
                    .Margin(5),
                new RxButton()
                    .Content("Increment")
                    .OnClick(()=>SetState(s => s.Counter++))
                    .Margin(5)
            }
            .VCenter()
            .HCenter();
        }
    }
}
