﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.UI.Xaml;

namespace ReactorWinUI.Internals
{
    public interface IPropertyValue
    { 
        bool SetDefault { get; }

        object GetValue();
    }

    public class PropertyValue<T> : IPropertyValue
    {
        private PropertyValue()
        {
            SetDefault = true;
        }
        public PropertyValue(T value)
        {
            Value = value;
        }

        public PropertyValue(Func<T> valueAction)
        {
            ValueAction = valueAction ?? throw new ArgumentNullException(nameof(valueAction));

            Value = valueAction();
        }

        public static IPropertyValue Default { get; } = new PropertyValue<T>();

        public T Value { get; }

        public Func<T> ValueAction { get; }

        public bool SetDefault { get; }

        public object GetValue() => Value;

        public override string ToString()
        {
            return $"{{{(Value == null ? "null" : Value.ToString())}}}";
        }
    }

    internal static class PropertyValueExtenstions
    {
        public static void Set(this DependencyObject dependencyObject, IVisualNodeWithNativeControl visualNode, DependencyProperty property, IPropertyValue propertyValue)
        {
            if (propertyValue != null)
            {
                visualNode.SetDefaultPropertyValue(property, dependencyObject.GetValue(property));
                dependencyObject.SetValue(property, propertyValue.GetValue());

            }
            else
            {
                if (visualNode.TryGetDefaultPropertyValue(property, out var defaultValue))
                {
                    dependencyObject.SetValue(property, defaultValue);
                }            
            }            
        }
    }
}
