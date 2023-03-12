using Microsoft.Extensions.Logging;

namespace RaspCalc;

public static class MauiProgram
{

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder().UseMauiApp<App>()
            .ConfigureFonts(fonts => fonts
                .AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold"));
            
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

}
