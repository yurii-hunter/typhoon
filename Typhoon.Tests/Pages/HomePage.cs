using Typhoon.Infrastructure.BaseTypes.Page;
using Typhoon.Infrastructure.Factory;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Tests.Pages
{
    [Url("/")]
    class HomePage : WebPage
    {
        [FindBy(How.CssSelector, "div.cover-container")]
        public CoverItem CoverItem { get; set; }
    }
}
