using System.Collections.Generic;
using OpenQA.Selenium;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure
{
    public interface INative
    {
        IWebElement FindElement(Locator locator, int index);
        IReadOnlyCollection<IWebElement> FindElements(Locator locator);
    }
}