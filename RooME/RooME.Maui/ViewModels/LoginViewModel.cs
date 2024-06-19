
namespace RooME.Maui.ViewModels;
public partial class LoginViewModel : BaseViewModel
{
    private readonly IUserService _userService;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _email;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _password;
    
    public LoginViewModel(IUserService userService)
    {
        _userService = userService;
    }

    public override void OnNavigatedTo(IDictionary<string, object> data)
    {
        base.OnNavigatedTo(data);
    }

    [RelayCommand(CanExecute =nameof(CanLogin))]
    private async Task LoginAsync()
    {
        await _userService.LoginAsync(Email!, Password!);
    }

    private bool CanLogin() => !(string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email));
}
