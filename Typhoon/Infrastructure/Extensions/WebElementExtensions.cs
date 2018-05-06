using System;
using System.Linq;
using OpenQA.Selenium;
using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Infrastructure.Extensions
{
    internal static class WebElementExtensions
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                // Poke element.
                // ReSharper disable once UnusedVariable
                var text = element.Text;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public static class WebElementMethods
    {
        public static bool HasClass(this IHtmlElement element, string className)
        {
            var classValue = element.GetProperty("class");
            var classes = classValue.Split(' ');
            return classes.Any(i => i.Equals(className, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
