
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace RooME.Maui.Views;

public partial class MainPage : BasePage
{
	public MainPage(MainViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
        ToastAsync();
	}

    private async void ToastAsync()
    {
        var toast = Toast.Make("Toast works! :-)", ToastDuration.Long);
        await toast.Show();
    }
}
