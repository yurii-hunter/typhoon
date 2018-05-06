using System;
using System.Reflection;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure.Factory
{
    internal static class ElementFactory
    {
        internal static void InitProperties(INative htmlElement)
        {
            var properties = htmlElement.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                if (property.HasLocatorAttribute() && property.IsHtmlElement())
                {
                    var element = Create(property.PropertyType, htmlElement, property.GetLocatorAttribute());
                    property.SetValue(htmlElement, element);
                }
                if (property.HasLocatorAttribute() && property.IsHtmlElementCollection())
                {
                    var collection = CollectionFactory.Create(property.PropertyType, htmlElement,
                        property.GetLocatorAttribute());
                    property.SetValue(htmlElement, collection);
                }
                if (property.HasLocatorAttribute() && !(property.IsHtmlElement() || property.IsHtmlElementCollection()))
                {
                    throw new InvalidOperationException(
                        $"Property {property.Name} has FindBy attribute but is not collection or element");
                }
            }
        }

        public static TElement Create<TElement>(INative parent, Locator locator) where TElement : IHtmlElement
        {
            return (TElement)Create(typeof(TElement), parent, locator);
        }

        public static TElement Create<TElement>(INative parent, Locator locator, int index) where TElement : IHtmlElement, new()
        {
            return (TElement) Create(typeof(TElement), parent, locator, index);
        }

        private static IHtmlElement Create(Type elementType, INative parent, Locator locator, int index = 0)
        {
            var htmlElement = (IHtmlElement) Activator.CreateInstance(elementType);
            htmlElement.Parent = parent;
            htmlElement.SearchStrategy = new SearchStrategy(locator, index);
            InitProperties(htmlElement);
            return htmlElement;
        }
    }
}
