namespace RooME.Maui.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = default!;

    [ObservableProperty]
    private bool _isBusy = false;

    //partial void OnIsBusyChanging(bool oldValue, bool newValue)
    //{
    //    Title = $"Old: {oldValue}, new: {newValue}";
    //}

    public virtual void OnNavigatedTo(IDictionary<string, object> data=default!)
    {
    }
}
