using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Behavior
{
    public static class ElementBehaviorExtension
    {
        public static TBehavior WrapAs<TBehavior>(this IHtmlElement element) where TBehavior : IBehavior, new()
        {
            return new TBehavior {WrappedElement = element};
        }
    }
}
