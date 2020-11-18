using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Linq;


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

namespace ReactorWinUI
{
    public partial interface IRxContentControl
    {

    }

    public partial class RxUserControl<T> : IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _contents = new List<VisualNode>();
        public RxUserControl(VisualNode content)
        {
            _contents.Add(content);
        }

        public void Add(VisualNode child)
        {
            if (child is VisualNode && _contents.Any())
                throw new InvalidOperationException("Content already set");

            _contents.Add(child);
        }

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _contents.GetEnumerator();
        }
        
        protected override void OnAddChild(VisualNode widget, DependencyObject childControl)
        {
            OnAddChildCore(widget, childControl);

            base.OnAddChild(widget, childControl);
        }

        protected virtual void OnAddChildCore(VisualNode widget, DependencyObject childControl)
        {
            if (childControl is UIElement contentElement)
                NativeControl.Content = contentElement;
            else
            {
                throw new NotSupportedException();
            }
        }

        protected override void OnRemoveChild(VisualNode widget, DependencyObject childControl)
        {
            OnRemoveChildCore(widget, childControl);

            base.OnRemoveChild(widget, childControl);
        }

        protected virtual void OnRemoveChildCore(VisualNode widget, DependencyObject childControl)
        {
            NativeControl.Content = null;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _contents;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        partial void OnBeginUpdate()
        {

        }
    }

    public static partial class RxUserControlExtensions
    {


    }
}
