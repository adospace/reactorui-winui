using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ReactorWinUI.DemoApp
{
    [EntryComponent]
    public class HomeComponent : RxComponent
    {
        public override VisualNode Render()
        {
            return new RxFrame()
            {
                new RxPage()
                {
                     new RxButton()
                        .Content("Hello World ReactorUI!")
                        .OnClick(OnButtonClicked)
                        .VCenter()
                        .HCenter()
                }
            };
        }

        private void OnButtonClicked()
        {
            
        }
    }
}
