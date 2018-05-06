using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Typhoon.Configuration;
using Typhoon.Infrastructure.Extensions;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure.Driver
{
    public sealed class WebDriver : IWebDriver, IJavaScriptExecutor
    {
        private OpenQA.Selenium.IWebDriver _nativeDriver;

        internal OpenQA.Selenium.IWebDriver NativeDriver
        {
            get
            {
                if (!IsRunning)
                    _nativeDriver = InitDriver();
                return _nativeDriver;
            }
        }

        public bool IsRunning
        {
            get { return _nativeDriver != null && _nativeDriver.Alive(); }
        }

        private OpenQA.Selenium.IWebDriver InitDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("disable-infobars");
            var nativeDriver = new ChromeDriver(GetChromeDriverService(), chromeOptions);
            nativeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TyphoonConfig.Typhoon.Timeout.Implicit);
            nativeDriver.Manage().Window.Maximize();
            return nativeDriver;
        }

        private static ChromeDriverService GetChromeDriverService()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            return chromeDriverService;
        }

        IWebElement INative.FindElement(Locator locator, int index)
        {
            return NativeDriver.FindElement(locator.ToSeleniumLocator());
        }

        IReadOnlyCollection<IWebElement> INative.FindElements(Locator locator)
        {
            return NativeDriver.FindElements(locator.ToSeleniumLocator());
        }

        public void Get(string url)
        {
            NativeDriver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            _nativeDriver?.Quit();
        }

        public string Url
        {
            get { return NativeDriver.Url; }
        }

        public string Title
        {
            get { return NativeDriver.Title; }
        }

        public void TakeScreenshot(string fileName)
        {
            ((ITakesScreenshot)NativeDriver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }

        object IJavaScriptExecutor.ExecuteScript(string script, params object[] args)
        {
            return ((OpenQA.Selenium.IJavaScriptExecutor) NativeDriver).ExecuteScript(script, args);
        }

        public void Dispose()
        {
            _nativeDriver?.Quit();
        }

        public void Refresh()
        {
            NativeDriver.Navigate().Refresh();
        }
    }
}