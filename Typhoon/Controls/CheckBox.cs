using Typhoon.Controls.Abstract;
using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Controls
{
    public class CheckBox : HtmlElement, ICheckBox
    {
        public void Check()
        {
            if (!Checked)
                Click();
        }

        public void Uncheck()
        {
            if (Checked)
                Click();
        }

        public bool Checked
        {
            get { return bool.Parse(GetAttribute("checked")); }
        }
    }
}
