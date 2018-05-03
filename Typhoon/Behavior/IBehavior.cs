using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Behavior
{
    public interface IBehavior
    {
        IHtmlElement WrappedElement { get; set; }
    }
}
