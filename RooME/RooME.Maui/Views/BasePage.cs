
namespace RooME.Maui.Views;

public class BasePage : ContentPage, IQueryAttributable
{
    public BasePage(BaseViewModel viewModel)
    {
        BindingContext = ViewModel = viewModel;  
    }

    public BaseViewModel ViewModel { get; private set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ViewModel.OnNavigatedTo(query);
    }
}
