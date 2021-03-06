﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Reflection;


using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;

using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Media3D;

using Windows.UI.Text;
using Windows.Foundation;

using ReactorWinUI.Internals;
using System.Linq;

namespace ReactorWinUI
{
    public partial class RxPanel<T> : IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _internalChildren = new List<VisualNode>();

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _internalChildren;
        }

        protected override void OnAddChild(VisualNode widget, object childControl)
        {
            if (childControl is UIElement control)
            {
                NativeControl.Children.Insert(widget.ChildIndex, control);
            }
            else
            {
                throw new InvalidOperationException($"Type '{childControl.GetType()}' not supported under '{GetType()}'");
            }

            base.OnAddChild(widget, childControl);
        }

        protected override void OnRemoveChild(VisualNode widget, object childControl)
        {
            NativeControl.Children.Remove((UIElement)childControl);

            base.OnRemoveChild(widget, childControl);
        }

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _internalChildren.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _internalChildren.GetEnumerator();
        }

        public void Add(params VisualNode[] nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            foreach (var node in nodes)
                _internalChildren.Add(node);
        }

        public void Add(object genericNode)
        {
            if (genericNode == null)
            {
                return;
            }

            if (genericNode is VisualNode visualNode)
            {
                _internalChildren.Add(visualNode);
            }
            else if (genericNode is IEnumerable nodes)
            {
                foreach (var node in nodes.Cast<VisualNode>())
                    _internalChildren.Add(node);
            }
            else
            {
                throw new NotSupportedException($"Unable to add value of type '{genericNode.GetType()}' under {typeof(T)}");
            }
        }

    }
}
