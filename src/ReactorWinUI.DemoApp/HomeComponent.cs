namespace ReactorWinUI.DemoApp
{
    internal class HomeComponent : RxComponent
    {
        public override VisualNode Render() => new RxTextBlock()
                .Text("Hello World ReactorWinUI!")
                .VCenter()
                .HCenter();
    }
}