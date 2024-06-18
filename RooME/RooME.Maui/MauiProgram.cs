namespace RooME.Maui;

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

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<ListDetailDetailViewModel>();
		builder.Services.AddTransient<ListDetailDetailPage>();
		builder.Services.AddSingleton<ChatViewModel>();
		builder.Services.AddSingleton<ChatPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddSingleton<ILocalizationService>(Span=>new ResXLocalizationService { CurrentCulture = new System.Globalization.CultureInfo("fr") });

		return builder.Build();
	}
}
