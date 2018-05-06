using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Controls.Abstract
{
    public interface ITextBox : IHtmlElement
    {
        void SetText(string text);
        void Clear();
    }
}