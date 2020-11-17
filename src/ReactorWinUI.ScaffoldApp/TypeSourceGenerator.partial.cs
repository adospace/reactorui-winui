using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReactorWinUI.ScaffoldApp
{
    public partial class TypeSourceGenerator
    {
        private readonly Type _typeToScaffold;

        public TypeSourceGenerator(Type typeToScaffold)
        {
            _typeToScaffold = typeToScaffold;

            var propertiesMap = _typeToScaffold.GetProperties()
                //generic types not supported
                .Where(_ => !_.PropertyType.IsGenericType)
                //excluding common properties not relevant to ReactorUI framework
                .Where(_ => !typeof(FrameworkTemplate).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(GroupStyleSelector).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(StyleSelector).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(DataTemplateSelector).IsAssignableFrom(_.PropertyType))

                //.Where(_ => !(_typeToScaffold == typeof(ContentControl) && _.Name == "Content"))
                //.Where(_ => !(_typeToScaffold == typeof(UserControl) && _.Name == "Content"))

                .Where(_ => _.PropertyType != typeof(ICommand))
                .Where(_ => _.Name.IndexOf("CommandParameter") == -1)

                .Distinct(new PropertyInfoEqualityComparer())
                .ToDictionary(_ => _.Name, _ => _);
            
            Properties = _typeToScaffold.GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(_ => typeof(DependencyProperty).IsAssignableFrom(_.PropertyType))
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .Select(_ => _.Name.Substring(0, _.Name.Length - "Property".Length))
                .Where(_ => propertiesMap.ContainsKey(_))
                .Select(_ => propertiesMap[_])
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .Where(_ => !_.PropertyType.IsGenericType)
                .Where(_ => (_.GetSetMethod()?.IsPublic).GetValueOrDefault())
                .OrderBy(_ => _.Name)
                .ToArray();

            //var eventsMap = _typeToScaffold.GetEvents()
            //    .Distinct(new EventInfoEqualityComparer())
            //    .ToDictionary(_ => _.Name, _ => _);

            //Events = _typeToScaffold.GetProperties(BindingFlags.Public | BindingFlags.Static)
            //    .Where(_ => 
            //        typeof(RoutedEvent).IsAssignableFrom(_.PropertyType) ||
            //        typeof(RoutedEventHandler).IsAssignableFrom(_.PropertyType))
            //    .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
            //    .Select(_ => _.Name.Substring(0, _.Name.Length - "Event".Length))
            //    .Where(_ => eventsMap.ContainsKey(_))
            //    .Select(_ => eventsMap[_])
            //    .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
            //    .OrderBy(_ => _.Name)
            //    .ToArray();

            Events = typeToScaffold.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(_ =>
                        typeof(RoutedEvent).IsAssignableFrom(_.EventHandlerType) ||
                        typeof(RoutedEventHandler).IsAssignableFrom(_.EventHandlerType))
                    .Distinct(new EventInfoEqualityComparer())
                    .OrderBy(_ => _.Name)
                    .ToArray();
        }

        public string TypeName => _typeToScaffold.Name;

        public string BaseTypeName => _typeToScaffold.BaseType.Name == "DependencyObject" ? "VisualNode" : $"Rx{_typeToScaffold.BaseType.Name}";

        public bool IsTypeNotAbstractNotSealedWithEmptyConstructor => !_typeToScaffold.IsAbstract && !_typeToScaffold.IsSealed && _typeToScaffold.GetConstructor(new Type[] { }) != null;

        public bool IsSealed => _typeToScaffold.IsSealed;

        public PropertyInfo[] Properties { get; }

        public EventInfo[] Events { get; }

        public string GetEventArgsTypeName(EventInfo eventInfo)
        {
            return eventInfo.EventHandlerType.GetMethod("Invoke").GetParameters()[1].ParameterType.Name;
        }

        public string TransformAndPrettify()
        {
            var tree = CSharpSyntaxTree.ParseText(TransformText());

            var workSpace = new AdhocWorkspace();
            workSpace.AddSolution(
                      SolutionInfo.Create(SolutionId.CreateNewId("formatter"),
                      VersionStamp.Default)
            );

            var formatter = Formatter.Format(tree.GetCompilationUnitRoot(), workSpace);
            return formatter.ToString();
        }
    }

    internal class PropertyInfoEqualityComparer : IEqualityComparer<PropertyInfo>
    {
        public bool Equals(PropertyInfo x, PropertyInfo y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(PropertyInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    internal class EventInfoEqualityComparer : IEqualityComparer<EventInfo>
    {
        public bool Equals(EventInfo x, EventInfo y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(EventInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    internal static class StringExtensions
    {
        public static string CamelCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;
            return Char.ToLowerInvariant(s[0]) + s.Substring(1, s.Length - 1);
        }

        public static string ToResevedWordTypeName(this string typename)
        {
            switch (typename)
            {
                case "SByte": return "sbyte";
                case "Byte": return "byte";
                case "Int16": return "short";
                case "UInt16": return "ushort";
                case "Int32": return "int";
                case "UInt32": return "uint";
                case "Int64": return "long";
                case "UInt64": return "ulong";
                case "Char": return "char";
                case "Single": return "float";
                case "Double": return "double";
                case "Boolean": return "bool";
                case "Decimal": return "decimal";
                case "String": return "string";
                case "Object": return "object";
                default: return typename;
            };
        }
    }

}
