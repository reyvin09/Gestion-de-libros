using BookTracker.Services;
using BookTracker.ViewModels;
using Microsoft.Extensions.Logging;

namespace BookTracker
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


            // Ruta de la base de datos
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db3");

            // Registrar el servicio de base de datos como Singleton
            builder.Services.AddSingleton(new BookDatabase(dbPath));

            builder.Services.AddSingleton<DashboardViewModel>();

            return builder.Build();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
