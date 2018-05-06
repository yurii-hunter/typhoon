using System;
using Typhoon.Configuration;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Tools;

namespace Typhoon.Infrastructure.Extensions
{
    public static class WaitExtensions
    {
        private static void WaitForCondition<TElement>(this TElement element, Func<TElement, bool> condition,
            string message, TimeSpan? timeout = null)
            where TElement : IHtmlElement
        {
            var conditionIsFulfilled = Wait.For(() => condition(element),
                timeout?.Seconds ?? TyphoonConfig.Typhoon.Timeout.Explicit);
            if (!conditionIsFulfilled)
                throw new InvalidOperationException(message);
        }

        public static void WaitForDisplayed(this IHtmlElement element, TimeSpan? timeout = null)
        {
            element.WaitForCondition(i=>i.Displayed, $"Element {element} is not displayed after timeout");
        }

        public static void WaitForNotDisplayed(this IHtmlElement element, TimeSpan? timeout = null)
        {
            element.WaitForCondition(i => !i.Displayed, $"Element {element} is displayed after timeout");
        }

        public static void WaitForExists(this IHtmlElement element, TimeSpan? timeout = null)
        {
            element.WaitForCondition(i => i.Exists, $"Element {element} does not exist after timeout");
        }

        public static void WaitForNotExists(this IHtmlElement element, TimeSpan? timeout = null)
        {
            element.WaitForCondition(i => !i.Exists, $"Element {element} exists after timeout");
        }

        public static void WaitForEnabled(this IHtmlElement element, TimeSpan? timeout = null)
        {
            element.WaitForCondition(i => i.Enabled, $"Element {element} is not enabled after timeout");
        }

        public static void WaitForNotEnabled(this IHtmlElement element, TimeSpan? timeout = null)
        {
            element.WaitForCondition(i => !i.Enabled, $"Element {element} is enabled after timeout");
        }
    }
}
