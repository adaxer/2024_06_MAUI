using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using RooME.Maui.Interfaces;

namespace RooME.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ChatViewModel>();
        builder.Services.AddSingleton<ChatPage>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddSingleton<RoomListViewModel>();
        builder.Services.AddSingleton<RoomListPage>();

        builder.Services.AddTransient<RoomDetailsViewModel>();
        builder.Services.AddTransient<RoomDetailsPage>();

        builder.Services.AddTransient<IRoomService, ApiRoomService>();
        builder.Services.AddSingleton<ILocalizationService>(sp => new ResXLocalizationService { CurrentCulture = new System.Globalization.CultureInfo("fr") });
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        builder.Services.AddSingleton<IUserService, MauiUserService>();
       // builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://9cf3180h-7195.euw.devtunnels.ms", UriKind.Absolute) });
        builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7195", UriKind.Absolute) });
        builder.Services.AddSingleton<IMessenger, WeakReferenceMessenger>();
        builder.Services.AddSingleton<IStatusService, MauiStatusService>();

        var mauiApp = builder.Build();
        return mauiApp;
    }
}
