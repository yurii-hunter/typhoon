using System.Collections.Generic;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure
{
    public interface ISearchable
    {
        TElement Find<TElement>(Locator locator) where TElement : IHtmlElement, new();
        IEnumerable<TElement> FindAll<TElement>(Locator locator) where TElement : IHtmlElement, new();
    }
}
