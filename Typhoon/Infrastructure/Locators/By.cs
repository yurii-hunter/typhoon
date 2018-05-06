namespace Typhoon.Infrastructure.Locators
{
    public static class By
    {
        public static Locator Id(string id)
        {
            return new Locator(How.Id, id);
        }

        public static Locator XPath(string xpath)
        {
            return new Locator(How.XPath, xpath);
        }

        public static Locator CssSelector(string cssSelector)
        {
            return new Locator(How.CssSelector, cssSelector);
        }

        public static Locator TagName(string tagName)
        {
            return new Locator(How.TagName, tagName);
        }

        public static Locator ClassName(string className)
        {
            return new Locator(How.ClassName, className);
        }

        public static Locator LinkText(string linkText)
        {
            return new Locator(How.LinkText, linkText);
        }

        public static Locator Name(string name)
        {
            return new Locator(How.Name, name);
        }

        public static Locator PartialLinkText(string partialLink)
        {
            return new Locator(How.PartialLinkText, partialLink);
        }

        // ReSharper disable once InconsistentNaming
        public static Locator jQuery(string selector)
        {
            return new Locator(How.jQuery, selector);
        }
    }
}