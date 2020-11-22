﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using ReactorWinUI.Internals;
using Microsoft.UI.Xaml;

namespace ReactorWinUI
{
    public interface IRxComponent
    {
        RxContext Context { get; }
    }

    public abstract class RxComponent : VisualNodeWithAttachedProperties, IEnumerable<VisualNode>
    {

        private readonly List<VisualNode> _children = new();
        private readonly Dictionary<DependencyProperty, object> _attachedProperties = new();

        public abstract VisualNode Render();

        public override void SetAttachedProperty(DependencyProperty property, object value)
            => _attachedProperties[property] = value;

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }   

        public void Add(params VisualNode[] nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            _children.AddRange(nodes);
        }

        protected new IReadOnlyList<VisualNode> Children()
            => _children;

        private IRxHostElement GetPageHost()
        {
            var current = Parent;
            while (current != null && !(current is IRxHostElement))
                current = current.Parent;

            return current as IRxHostElement;
        }

        protected sealed override void OnAddChild(VisualNode widget, object nativeControl)
        {
            if (nativeControl is DependencyObject childAsDependencyObject)
            {
                foreach (var attachedProperty in _attachedProperties)
                {
                    childAsDependencyObject.SetValue(attachedProperty.Key, attachedProperty.Value);
                }
            }

            Parent.AddChild(this, nativeControl);
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object nativeControl)
        {
            Parent.RemoveChild(this, nativeControl);

            if (nativeControl is DependencyObject childAsDependencyObject)
            {
                foreach (var attachedProperty in _attachedProperties)
                {
                    childAsDependencyObject.ClearValue(attachedProperty.Key);
                }
            }
        }

        protected override TChild OnCreatChild<TChild>() 
            => Parent?.CreateChild<TChild>();

        protected sealed override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Render();
        }

        protected sealed override void OnUpdate()
        {
            base.OnUpdate();
        }

        protected sealed override void OnAnimate()
        {
            base.OnAnimate();
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode.GetType().FullName == GetType().FullName)
            {
                ((RxComponent)newNode)._isMounted = true;
                ((RxComponent)newNode).OnUpdated();
                base.MergeWith(newNode);
            }
            else
            {
                Unmount();
            }
        }

        protected sealed override void OnMount()
        {
            //System.Diagnostics.Debug.WriteLine($"Mounting {Key ?? GetType()} under {Parent.Key ?? Parent.GetType()} at index {ChildIndex}");

            base.OnMount();

            OnMounted();
        }

        protected virtual void OnMounted()
        {
        }

        protected sealed override void OnUnmount()
        {
            OnWillUnmount();

            foreach (var child in base.Children)
            {
                child.Unmount();
            }

            base.OnUnmount();
        }

        protected virtual void OnWillUnmount()
        {
        }

        protected virtual void OnUpdated()
        { }

        public INavigation Navigation
        {
            get
            {
                var parent = Parent;
                var navigation = parent as INavigation;
                while (navigation == null &&
                    parent != null)
                {
                    parent = parent.Parent;
                    navigation = parent as INavigation;
                }

                return navigation ?? throw new InvalidOperationException();
            }            
        }

        public RxContext Context
            => RxApplication.Instance.Context;

    }

    public static class RxComponentExtensions
    {
        public static T WithContext<T>(this T node, string key, object value) where T : IRxComponent
        {
            node.Context[key] = value;
            return node;
        }
    }

    internal interface IRxComponentWithState
    {
        object State { get; }

        PropertyInfo[] StateProperties { get; }

        void ForwardState(object stateFromOldComponent);

        IRxComponentWithState NewComponent { get; }
    }

    internal interface IRxComponentWithProps
    {
        object Props { get; }

        PropertyInfo[] PropsProperties { get; }
    }

    public interface IState
    {
    }

    public interface IProps
    {
    }

    public abstract class RxComponentWithProps<P> : RxComponent, IRxComponentWithProps where P : class, IProps, new()
    {
        public RxComponentWithProps(P props = null)
        {
            Props = props ?? new P();
        }

        public P Props { get; private set; }
        object IRxComponentWithProps.Props => Props;
        public PropertyInfo[] PropsProperties => typeof(P).GetProperties().Where(_ => _.CanWrite).ToArray();
    }

    public abstract class RxComponent<S, P> : RxComponentWithProps<P>, IRxComponentWithState where S : class, IState, new() where P : class, IProps, new()
    {
        private IRxComponentWithState _newComponent;
        
        protected RxComponent(S state = null, P props = null)
            : base(props)
        {
            State = state ?? new S();
        }

        public S State { get; private set; }

        public PropertyInfo[] StateProperties => typeof(S).GetProperties().Where(_ => _.CanWrite).ToArray();

        object IRxComponentWithState.State => State;

        void IRxComponentWithState.ForwardState(object stateFromOldComponent)
        {
            stateFromOldComponent.CopyPropertiesTo(State, StateProperties);

            RxApplication.Instance.SafeInvoke(Invalidate);
        }

        IRxComponentWithState IRxComponentWithState.NewComponent => _newComponent;

        private bool TryForworadStateToNewComponent()
        {
            var newComponent = _newComponent;
            while (newComponent != null && _newComponent.NewComponent != null)
                newComponent = _newComponent.NewComponent;

            if (_newComponent != null)
            {
                _newComponent.ForwardState(State);
                return true;
            }

            return false;
        }

        protected virtual void SetState(Action<S> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            action(State);

            if (TryForworadStateToNewComponent())
                return;

            RxApplication.Instance.SafeInvoke(Invalidate);
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode is IRxComponentWithState newComponentWithState)
            {
                _newComponent = newComponentWithState;

                State.CopyPropertiesTo(newComponentWithState.State, newComponentWithState.StateProperties);
            }

            if (newNode is IRxComponentWithProps newComponentWithProps)
            {
                Props.CopyPropertiesTo(newComponentWithProps.Props, newComponentWithProps.PropsProperties);
            }

            base.MergeWith(newNode);
        }
    }

    public class EmptyProps : IProps
    { }

    public abstract class RxComponent<S> : RxComponent<S, EmptyProps> where S : class, IState, new()
    {
        protected RxComponent(S state = null, EmptyProps props = null)
            : base(state, props)
        {
        }
    }

}
