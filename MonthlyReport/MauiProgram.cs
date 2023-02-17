using Microsoft.Extensions.Logging;
using MonthlyReport.Data.Services;
using MudBlazor.Services;

namespace MonthlyReport;

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

		// Set path to the SQLite database (it will be created if it does not exist)
		var dbPath =
			Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				@"WeatherForecasts.db");
		var dbCustomerPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Customer.db");
		var dbItemPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Item.db");
		var dbReciptPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Recipt.db");
		// Register WeatherForecastService and the SQLite database
		builder.Services.AddSingleton<WeatherForecastService>(
			s => ActivatorUtilities.CreateInstance<WeatherForecastService>(s, dbPath));
		builder.Services.AddSingleton<CustomerService>(s => ActivatorUtilities.CreateInstance<CustomerService>(s, dbCustomerPath));
		builder.Services.AddSingleton<ItemService>(s => ActivatorUtilities.CreateInstance<ItemService>(s, dbItemPath));
		builder.Services.AddSingleton<ReciptService>(s => ActivatorUtilities.CreateInstance<ReciptService>(s, dbReciptPath));


		return builder.Build();
	}
}
