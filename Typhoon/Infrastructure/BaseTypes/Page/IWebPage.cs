namespace Typhoon.Infrastructure.BaseTypes.Page
{
    public interface IWebPage : ISearchable, INative
    {
        string Address { get; set; }
        void Open();
        string Title { get; set; }
        void Refresh();
        void WaitForLoaded();
        void ScrollDown();
    }
}
