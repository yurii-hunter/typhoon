using Typhoon.Configuration;
using Typhoon.Infrastructure.BaseTypes.Page;

namespace Typhoon.Infrastructure.Factory
{
    public static class PageFactory
    {
        public static TPage Get<TPage>() where TPage : IWebPage, new()
        {
            IWebPage page = new TPage();
            InitPage(page);
            return (TPage) page;
        }

        private static void InitPage(IWebPage page)
        {
            if (page.GetType().HasUrlAttribute())
                page.Address = TyphoonConfig.Typhoon.Application.BaseUrl + page.GetType().GetUrlAttribute().Url;
            ElementFactory.InitProperties(page);
        }
    }
}
