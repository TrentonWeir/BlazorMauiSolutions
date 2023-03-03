using DailyTasks.Data;
using DailyTasks.Data.Services;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Projects.Data.Services;
using Updates.Data.Services;

namespace DailyTasks
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            var dbPath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"DailyTasks.db"
            );
            var dbProjectPath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"Project.db"
            );
            var dbUpdatePath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"Update.db"
            );
            builder.Services.AddSingleton<DailyTaskService>(s => ActivatorUtilities.CreateInstance<DailyTaskService>(s, dbPath));
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<UpdateService>(s, dbUpdatePath));
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<ProjectService>(s, dbProjectPath));
            return builder.Build();
        }
    }
}