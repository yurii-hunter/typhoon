using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure.Factory
{
    internal static class PropertyExtension
    {
        internal static bool IsHtmlElement(this PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsHtmlElement();
        }

        internal static bool IsHtmlElement(this Type type)
        {
            return type.GetInterfaces().Any(i => i == (typeof(IHtmlElement)));
        }

        internal static bool HasLocatorAttribute(this PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.CustomAttributes;
            return attributes.Any(attribute => attribute.AttributeType == typeof(FindByAttribute));
        }

        internal static Locator GetLocatorAttribute(this PropertyInfo propertyInfo)
        {
            var findByAttribute =
                (FindByAttribute) Attribute.GetCustomAttribute(propertyInfo, typeof (FindByAttribute));
            return findByAttribute.ToLocator();
        }

        internal static bool HasUrlAttribute(this Type pageType)
        {
            var attributes = pageType.CustomAttributes;
            return attributes.Any(attribute => attribute.AttributeType == typeof(UrlAttribute));
        }

        internal static UrlAttribute GetUrlAttribute(this Type pageType)
        {
            var urlAttribute = (UrlAttribute) Attribute.GetCustomAttribute(pageType, typeof (UrlAttribute));
            return urlAttribute;
        }

        internal static bool IsHtmlElementCollection(this PropertyInfo propertyInfo)
        {
            if (!propertyInfo.PropertyType.IsGenericType) return false;
            var interfaces = propertyInfo.PropertyType.GetInterfaces();
            if (interfaces.All(i => i != typeof(IEnumerable))) return false;
            if (propertyInfo.PropertyType.GenericTypeArguments.Length != 1) return false;
            return propertyInfo.PropertyType.GenericTypeArguments.Single().IsHtmlElement();
        }
    }
}
