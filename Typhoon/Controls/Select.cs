using OpenQA.Selenium.Support.UI;
using Typhoon.Controls.Abstract;
using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Controls
{
    public class Combobox : HtmlElement, ISelect
    {
        public void Select(string value)
        {
            var selectElement = new SelectElement(NativeElement);
            selectElement.SelectByText(value);
        }

        public string GetSelected()
        {
            var selectElement = new SelectElement(NativeElement);
            return selectElement.SelectedOption.Text;
        }
    }
}