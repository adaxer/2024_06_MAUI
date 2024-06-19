using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Messaging;

namespace RooME.Maui.Services;
public class MauiStatusService : IStatusService
{
    public MauiStatusService(IMessenger messenger)
    {
        messenger.Register<StatusMessage>(this, async (_, statusMessage) =>
            await ShowStatus(statusMessage)
        );
    }

    public async Task ShowStatus(StatusMessage message)
    {
        var toast = Toast.Make(message.Status, ToastDuration.Long);
        await toast.Show();
    }
}
