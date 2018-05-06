using System;
using Typhoon.Infrastructure.Factory;

namespace Typhoon.Infrastructure.Locators
{
    internal static class LocatorConverter
    {
        internal static OpenQA.Selenium.By ToSeleniumLocator(this Locator locator)
        {
            switch (locator.How)
            {
                case How.Id:
                    return OpenQA.Selenium.By.Id(locator.Using);
                case How.CssSelector:
                    return OpenQA.Selenium.By.CssSelector(locator.Using);
                case How.TagName:
                    return OpenQA.Selenium.By.TagName(locator.Using);
                case How.XPath:
                    return OpenQA.Selenium.By.XPath(locator.Using);
                case How.ClassName:
                    return OpenQA.Selenium.By.ClassName(locator.Using);
                case How.LinkText:
                    return OpenQA.Selenium.By.LinkText(locator.Using);
                case How.Name:
                    return OpenQA.Selenium.By.Name(locator.Using);
                case How.PartialLinkText:
                    return OpenQA.Selenium.By.PartialLinkText(locator.Using);
                case How.jQuery:
                    return new ByJquery(locator.Using);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static Locator ToLocator(this FindByAttribute attribute)
        {
            var locator = new Locator(attribute.How, attribute.Using);
            return locator;
        }
    }
}