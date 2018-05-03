using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;
using Typhoon.Configuration;
using Typhoon.Infrastructure.Extensions;
using Typhoon.Infrastructure.Factory;
using Typhoon.Infrastructure.Locators;
using Typhoon.Tools;

namespace Typhoon.Infrastructure.BaseTypes.Element
{
    public class HtmlElement : IHtmlElement
    {
        protected const int RetryCount = 2;
        private IWebElement _nativeElement;
        protected IWebElement NativeElement
        {
            get
            {
                var timeout = Stopwatch.StartNew();
                Exception innerException = null;
                while (timeout.Elapsed <= TimeSpan.FromSeconds(TyphoonConfig.Typhoon.Timeout.Explicit))
                {
                    try
                    {
                        return ReInitNativeElement();
                    }
                    catch (NotFoundException ex)
                    {
                        innerException = ex;
                    }
                    catch (StaleElementReferenceException ex)
                    {
                        innerException = ex;
                    }
                    catch (InvalidElementStateException ex)
                    {
                        innerException = ex;
                    }
                }
                throw new ElementNotFoundException($"Can not find element {this}", innerException);
            }
        }

        private IWebElement ReInitNativeElement()
        {
            if (_nativeElement == null || !_nativeElement.Exists())
                _nativeElement = Parent.FindElement(SearchStrategy.Locator, SearchStrategy.Index);
            return _nativeElement;
        }

        public SearchStrategy SearchStrategy { get; set; }

        #region Navigation

        public INative Parent { get; set; }

        public TElement Find<TElement>(Locator locator) where TElement : IHtmlElement, new()
        {
            var element = ElementFactory.Create<TElement>(this, locator);
            return element;
        }

        public IEnumerable<TElement> FindAll<TElement>(Locator locator) where TElement : IHtmlElement, new()
        {
            var elementsCollection = CollectionFactory.Create<TElement>(this, locator);
            foreach (var element in elementsCollection)
            {
                yield return element;
            }
        }

        IWebElement INative.FindElement(Locator locator, int index)
        {
            return NativeElement.FindElement(locator.ToSeleniumLocator());
        }

        IReadOnlyCollection<IWebElement> INative.FindElements(Locator locator)
        {
            return NativeElement.FindElements(locator.ToSeleniumLocator());
        }

        #endregion

        #region Actions

        /// <summary>
        /// Attribute computed by browser (browser tool)
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public string GetAttribute(string attribute)
        {
            return Do.Retry(()=>NativeElement.GetAttribute(attribute));
        }

        /// <summary>
        /// Property you can read from HHML element
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string GetProperty(string property)
        {
            var propertyValue = Do.Retry(() => ((Driver.IJavaScriptExecutor) Driver.DriverService.Driver).ExecuteScript("return arguments[0].getAttribute(arguments[1]);", NativeElement, property), RetryCount);
            return propertyValue?.ToString();
        }

        public virtual bool Displayed
        {
            get
            {
                return Do.Retry(() => Exists && NativeElement.Displayed, RetryCount);
            }
        }

        public virtual bool Exists
        {
            get
            {
                try
                {
                    // Poke element.
                    // ReSharper disable once UnusedVariable
                    var text = ReInitNativeElement().Text;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public virtual bool Enabled
        {
            get
            {
                return Do.Retry(() => Displayed && NativeElement.Enabled, RetryCount);
            }
        }

        void IHtmlElement.SetNativeElement(IWebElement nativeElement)
        {
            _nativeElement = nativeElement;
        }

        IWebElement IHtmlElement.GetNativeElement()
        {
            return NativeElement;
        }

        public virtual void Click()
        {
            Wait.For(() =>
            {
                try
                {
                    NativeElement.Click();
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (InvalidOperationException e)
                {
                    if (e.Message.Contains("is not clickable at point"))
                        return false;
                    throw;
                }
            });
        }

        public virtual string GetText()
        {
            return Do.Retry(() =>
            {
                var textValue = NativeElement.Text;
                return textValue.IsNullOrEmpty() ? GetAttribute("textContent")?.Trim() : textValue;
            }, RetryCount);
        }

        public override string ToString()
        {
            string elementName = GetType().Name;
            string locator = SearchStrategy.Locator.ToString();
            return $"{elementName}. {locator}";
        }

        #endregion
    }
}