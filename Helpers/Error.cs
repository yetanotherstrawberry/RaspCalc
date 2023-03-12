using RaspCalc.Resources;

namespace RaspCalc.Helpers;

internal static class Error
{

    public static async void ShowError(string error)
    {
        await Application.Current.MainPage.DisplayAlert(AppRes.ERR_TITLE, error, AppRes.ERR_OK);
    }

    public static void ShowError(Exception exception) => ShowError(exception.Message);

}
