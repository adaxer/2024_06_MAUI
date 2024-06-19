using RooME.Maui.Interfaces;

namespace RooME.Maui.ViewModels;

public partial class RoomListViewModel : BaseViewModel
{
    readonly IRoomService _dataService;
    private readonly INavigationService _navigationService;
    private readonly IUserService _userService;
    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<Room>? rooms;

    [ObservableProperty]
    private bool _isLoggedIn=false;

    public RoomListViewModel(IRoomService service, INavigationService navigationService, IUserService userService)
    {
        _dataService = service;
        _navigationService = navigationService;
        _userService = userService;
    }

    public override async void OnNavigatedTo(IDictionary<string, object> data)
    {
        IsLoggedIn = await _userService.GetIsLoggedInAsync();
        if (IsLoggedIn)
        {
            await LoadDataAsync();
        }
    }

    [RelayCommand]
    private async Task OnRefreshingAsync()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task LoadMoreAsync()
    {
        if (Rooms is null)
        {
            return;
        }

        var moreItems = await _dataService.GetRoomsAsync();

        foreach (var item in moreItems)
        {
            Rooms.Add(item);
        }
    }

    public async Task LoadDataAsync()
    {
        Rooms = new ObservableCollection<Room>(await _dataService.GetRoomsAsync());
    }

    [RelayCommand]
    private async Task GoToDetailsAsync(Room item)
    {
        await _navigationService.NavigateAsync<RoomDetailsViewModel>(("Room", item));
    }

    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        await _navigationService.NavigateAsync<LoginViewModel>();
    }
}
