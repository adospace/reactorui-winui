﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorWinUI.DemoApp
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }

    public class ItemsControlComponentState : IState
    {
        public Item[] Items { get; set; }
        public Item SelectedItem { get; set; }
    }

    [EntryComponent]
    public class ItemsControlComponent : RxComponent<ItemsControlComponentState>
    {
        protected override void OnMounted()
        {
            SetState(s => s.Items = new[] { new Item("Item1"), new Item("Item2"), new Item("Item3") });
            base.OnMounted();
        }

        public override VisualNode Render() =>
            new RxListBox()
                .ItemsSource(State.Items)
                .SelectedItem(State.SelectedItem)
                //.OnSelectionChanged<RxListBox, Item>(item => SetState(s => s.SelectedItem = item))
                .OnRenderItem((Item item) => new RxTextBlock().Text(item.Name).FontSize(24))
                .FontSize(24)
                .VCenter()
                .HCenter();            
    }
}
