using OpenQA.Selenium;
using Typhoon.Infrastructure.Factory;

namespace Typhoon.Infrastructure.BaseTypes.Element
{
    public interface IHtmlElement : ISearchable, INative
    {
        void SetNativeElement(IWebElement nativeElement);
        IWebElement GetNativeElement();
        void Click();
        string GetText();
        bool Displayed { get; }
        bool Exists { get; }
        bool Enabled { get; }
        SearchStrategy SearchStrategy { get; set; }
        INative Parent { get; set; }
        string GetAttribute(string property);
        string GetProperty(string property);
    }
}
