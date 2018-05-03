using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Typhoon.Configuration;
using Typhoon.Infrastructure.BaseTypes.Collections;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Factory;
using Typhoon.Infrastructure.Locators;
using Typhoon.Tools;
using IJavaScriptExecutor = Typhoon.Infrastructure.Driver.IJavaScriptExecutor;

namespace Typhoon.Infrastructure.BaseTypes.Page
{
    using DriverService = Driver.DriverService;

    public abstract class WebPage : IWebPage
    {
        public TElement Find<TElement>(Locator locator) where TElement : IHtmlElement, new()
        {
            var element = ElementFactory.Create<TElement>(this, locator);
            return element;
        }

        public IEnumerable<TElement> FindAll<TElement>(Locator locator) where TElement : IHtmlElement, new()
        {
            IHtmlElementsCollection<TElement> elementsCollection = new HtmlElementsCollection<TElement>(this, locator);
            foreach (var element in elementsCollection)
            {
                yield return element;
            }
        }

        IWebElement INative.FindElement(Locator locator, int index)
        {
            return DriverService.Driver.FindElement(locator, index);
        }

        IReadOnlyCollection<IWebElement> INative.FindElements(Locator locator)
        {
            return DriverService.Driver.FindElements(locator);
        }

        public void Open()
        {
            DriverService.Driver.Get(((IWebPage)this).Address);
        }

        string IWebPage.Address { get; set; }

        string IWebPage.Title { get; set; }

        public virtual bool Opened
        {
            get { return DriverService.Driver.Url.StartsWith(((IWebPage) this).Address); }
        }

        public virtual void Refresh()
        {
            DriverService.Driver.Refresh();
        }

        public override string ToString()
        {
            return ((IWebPage)this).Address;
        }

        public virtual void WaitForOpened()
        {
            if (!Wait.For(()=>Opened, TyphoonConfig.Typhoon.Timeout.Explicit))
                throw new TimeoutException($"Page '{GetType().Name}' is not opened");
        }

        public virtual void WaitForLoaded()
        {
            WaitForOpened();
        }

        public virtual void ScrollDown()
        {
            var executor = (IJavaScriptExecutor) DriverService.Driver;
            executor.ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
        }
    }
}