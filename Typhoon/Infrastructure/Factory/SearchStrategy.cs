using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure.Factory
{
    public class SearchStrategy
    {
        public SearchStrategy(Locator locator)
        {
            Locator = locator;
        }

        public SearchStrategy(Locator locator, int index)
        {
            Locator = locator;
            Index = index;
        }

        public SearchStrategy()
        {
        }

        public Locator Locator { get; }
        public int Index { get; }
    }
}
