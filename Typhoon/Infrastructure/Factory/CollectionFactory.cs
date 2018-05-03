using System;
using Typhoon.Infrastructure.BaseTypes.Collections;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure.Factory
{
    internal static class CollectionFactory
    {
        internal static IHtmlElementsCollection<THtmlElement> Create<THtmlElement>(INative parent, Locator locator) where THtmlElement : IHtmlElement, new()
        {
            return new HtmlElementsCollection<THtmlElement>(parent, locator);
        }

        internal static object Create(Type type, INative parent, Locator locator)
        {
            var listType = typeof(HtmlElementsCollection<>);
            var genericArgs = type.GetGenericArguments();
            var concreteType = listType.MakeGenericType(genericArgs);
            var newList = Activator.CreateInstance(concreteType, parent, locator);
            return newList;
        }
    }
}