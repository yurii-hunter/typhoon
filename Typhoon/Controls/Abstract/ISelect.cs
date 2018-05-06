using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Controls.Abstract
{
    public interface ISelect : IHtmlElement
    {
        void Select(string value);
        string GetSelected();
    }
}