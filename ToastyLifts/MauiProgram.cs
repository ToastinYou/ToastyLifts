using Microsoft.Extensions.Logging;
using ToastyLifts.Interfaces;
using ToastyLifts.Services;
using ToastyLifts.ViewModels;
using ToastyLifts.Views;

namespace ToastyLifts;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.Register();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    /// <summary>
    /// Adds the application's services, view models, and views to the specified service collection.
    /// </summary>
    /// <param name="services">The application's <see cref="IServiceCollection"/>.</param>
    private static void Register(this IServiceCollection services)
    {
        // Services
        services.AddSingleton<IDatabaseService, DatabaseService>();

        // View Models
        services.AddTransient<MainViewModel>();

        // Views
        services.AddTransient<MainPage>();
    }
}
