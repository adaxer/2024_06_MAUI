using RooME.Maui.Interfaces;

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
		builder.Services.AddSingleton<ChatViewModel>();
		builder.Services.AddSingleton<ChatPage>();
		builder.Services.AddSingleton<RoomListViewModel>();
		builder.Services.AddSingleton<RoomListPage>();

        builder.Services.AddTransient<RoomDetailsViewModel>();
		builder.Services.AddTransient<RoomDetailsPage>();

		builder.Services.AddTransient<IRoomService, ApiRoomService>();
		builder.Services.AddSingleton<ILocalizationService>(Span=>new ResXLocalizationService { CurrentCulture = new System.Globalization.CultureInfo("fr") });
		builder.Services.AddSingleton<INavigationService, MauiNavigationService>();

		return builder.Build();
	}
}
