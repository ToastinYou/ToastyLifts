using Microsoft.Extensions.Logging;
using ToastyLifts.Interfaces;
using ToastyLifts.Services;
using ToastyLifts.ViewModels;

namespace ToastyLifts
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.RegisterServices();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        /// <summary>
        /// Adds the applications services and view models to the specified service collection.
        /// </summary>
        /// <param name="services">The application's <see cref="IServiceCollection"/>.</param>
        private static void RegisterServices(this IServiceCollection services)
        {
            // Services
            services.AddSingleton<IDatabaseService, DatabaseService>();

            // View Models
            services.AddTransient<MainViewModel>();
        }
    }
}
