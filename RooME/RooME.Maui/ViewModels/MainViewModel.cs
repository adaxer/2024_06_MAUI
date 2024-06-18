
namespace RooME.Maui.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _message = "";

    public MainViewModel(ILocalizationService localizationService)
    {
        Title = localizationService.Get("UI_AppTitle");
        WaitAndChange();
    }

    private async void WaitAndChange()
    {
        while (true)
        {
            await Task.Delay(1000);
            IsBusy = true;
            await Task.Delay(200);
            Message = $"It's {DateTime.Now}";
            IsBusy = false;
        }
    }
}
