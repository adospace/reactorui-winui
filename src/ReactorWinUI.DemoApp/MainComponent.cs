using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorWinUI.DemoApp
{
    public enum PageKind
    { 
        Home,

        CounterPage
    }

    public class Page
    {
        public Page(PageKind pageKind)
        {
            PageKind = pageKind;
        }

        public PageKind PageKind { get; }
    }

    public class MainComponentState : IState
    {
        public Page CurrentPage { get; set; }

        public Page[] Pages { get; set; }
    }

    [EntryComponent]
    public class MainComponent : RxComponent<MainComponentState>
    {
        protected override void OnMounted()
        {
            State.Pages = new[] { new Page(PageKind.Home), new Page(PageKind.CounterPage) };
            State.CurrentPage = State.Pages[0];

            base.OnMounted();
        }

        public override VisualNode Render()
        {
            return new RxWindow()
            {
                new RxGrid("*", "250 *")
                {
                    new RxListBox()
                        .ItemsSource(State.Pages)
                        .SelectedItem(State.CurrentPage)
                        .OnRenderItem((Page page) => new RxTextBlock().Text(page.PageKind.ToString()).FontSize(12))
                        .OnSelectedItemChanged((Page page) => SetState(s => s.CurrentPage = page, true))
                        ,

                    RenderPage()
                        .GridColumn(1),
                }
            };
        }

        private VisualNodeWithAttachedProperties RenderPage() => 
            State.CurrentPage.PageKind switch
            {
                PageKind.Home => new HomeComponent(),
                PageKind.CounterPage => new CounterComponent(),
                _ => throw new NotImplementedException(),
            };
    }
}
