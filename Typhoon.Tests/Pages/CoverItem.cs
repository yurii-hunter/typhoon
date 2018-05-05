using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Factory;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Tests.Pages
{
    /// <summary>
    /// css - div.cover-container
    /// </summary>
    class CoverItem : HtmlElement
    {
        [FindBy(How.CssSelector, "h1.cover-heading")]
        public HtmlElement Title { get; set; }

        [FindBy(How.CssSelector, "p.lead")]
        public HtmlElement Lead { get; set; }
    }
}
