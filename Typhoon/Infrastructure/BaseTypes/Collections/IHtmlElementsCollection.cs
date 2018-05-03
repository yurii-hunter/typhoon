using System.Collections.Generic;
using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Infrastructure.BaseTypes.Collections
{
    public interface IHtmlElementsCollection<out THtmlElement>: IEnumerable<THtmlElement> where THtmlElement: IHtmlElement, new()
    {
    }
}