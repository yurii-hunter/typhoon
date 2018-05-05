using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using IJavaScriptExecutor = Typhoon.Infrastructure.Driver.IJavaScriptExecutor;

namespace Typhoon.Infrastructure.Locators
{
    internal class ByJquery : OpenQA.Selenium.By
    {
        private readonly string _selector;

        public ByJquery(string selector)
        {
            _selector = $"\"{selector}\"";
        }

        public override IWebElement FindElement(ISearchContext context)
        {
            var element = GetJavaScriptObject(context, 0);
            if (element is IWebElement) return (IWebElement) element;
            throw new NoSuchElementException("No element found with jQuery command: jQuery" + _selector);
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            var elements = GetJavaScriptObject(context) as ReadOnlyCollection<IWebElement>;
            return elements ?? new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }

        private object GetJavaScriptObject(ISearchContext context, int? index = null)
        {
            return context is IWebDriver
                ? FindElementsByJQuery(index)
                : FindRelatedElementsByJQuery((IWebElement) context, index);
        }

        private object FindElementsByJQuery(int? index)
        {
            return ((IJavaScriptExecutor) Driver.DriverService.Driver).ExecuteScript(
                $"return jQuery({_selector}).get({index})");
        }

        private object FindRelatedElementsByJQuery(IWebElement element, int? index)
        {
            return ((IJavaScriptExecutor) Driver.DriverService.Driver).ExecuteScript(
                $"return jQuery(arguments[0]).find({_selector}).get({index})", element);
        }
    }
}
