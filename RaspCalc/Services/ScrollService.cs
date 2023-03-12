using RaspCalc.Helpers;
using RaspCalc.Interfaces;

namespace RaspCalc.Services;

internal class ScrollService : IScrollService
{

    private readonly ScrollView _scrollView;

    public ScrollService(ScrollView scrollView) => _scrollView = scrollView;

    public async void ScrollEnd()
    {
        try
        {
            await _scrollView.ScrollToAsync(double.MaxValue, 0, false);
        }
        catch (Exception ex)
        {
            Error.ShowError(ex);
        }
    }

}
