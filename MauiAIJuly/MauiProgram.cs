using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Toolkit.Hosting;
using MauiAIJuly.Services;
using MauiAIJuly.ViewModels;
using MauiAIJuly.Views;

namespace MauiAIJuly;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register services
		builder.Services.AddSingleton<IEventService, EventService>();

		// Register view models
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddTransient<AddEventPageViewModel>();
		builder.Services.AddTransient<ShiftOverviewViewModel>();

		// Register pages
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<AddEventPage>();
		builder.Services.AddTransient<ShiftOverview>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
