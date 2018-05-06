using System;

namespace Typhoon.Infrastructure.Driver
{
    public static class DriverService
    {
        private static readonly Lazy<WebDriver> DriverInstance = new Lazy<WebDriver>();
        public static IWebDriver Driver
        {
            get { return DriverInstance.Value; }
        }
    }
}
