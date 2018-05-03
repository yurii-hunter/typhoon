using Typhoon.Controls.Abstract;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Tools;

namespace Typhoon.Controls
{
    public class TextBox : HtmlElement, ITextBox
    {
        public virtual void SetText(string text)
        {
            Do.Retry(()=>
            {
                NativeElement.Clear();
                NativeElement.SendKeys(text);
            }, RetryCount);
        }

        public virtual void Clear()
        {
            Do.Retry(()=>NativeElement.Clear(), RetryCount);
        }

        public override string GetText()
        {
            return GetAttribute("value") ?? string.Empty;
        }
    }
}
