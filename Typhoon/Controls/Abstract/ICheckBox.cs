using Typhoon.Infrastructure.BaseTypes.Element;

namespace Typhoon.Controls.Abstract
{
    internal interface ICheckBox : IHtmlElement
    {
        void Check();
        void Uncheck();
        bool Checked { get; }
    }
}
