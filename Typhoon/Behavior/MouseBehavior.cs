using OpenQA.Selenium.Interactions;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Driver;

namespace Typhoon.Behavior
{
    public class MouseBehavior : IBehavior
    {
        public IHtmlElement WrappedElement { get; set; }

        public void HoverOver()
        {
            var hoverOverAction = new Actions(((WebDriver) DriverService.Driver).NativeDriver);
            hoverOverAction.MoveToElement(WrappedElement.GetNativeElement()).Perform();
        }

        public void DoubleClick()
        {
            var doubleClickAction = new Actions(((WebDriver) DriverService.Driver).NativeDriver);
            doubleClickAction.DoubleClick(WrappedElement.GetNativeElement()).Perform();
        }

        public void ScrollToElement()
        {
            var sctollAction = new Actions(((WebDriver)DriverService.Driver).NativeDriver);
            sctollAction.MoveToElement(WrappedElement.GetNativeElement()).Perform();
        }
    }
}
