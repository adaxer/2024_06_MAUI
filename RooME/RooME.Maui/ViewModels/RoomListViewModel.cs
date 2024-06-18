using RooME.Maui.Interfaces;

namespace RooME.Maui.ViewModels;

public partial class RoomListViewModel : BaseViewModel
{
	readonly SampleDataService _dataService;
  private readonly INavigationService _navigationService;
  [ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ObservableCollection<Room>? rooms;

	public RoomListViewModel(SampleDataService service, INavigationService navigationService)
	{
		_dataService = service;
    _navigationService = navigationService;
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
		// Zielkonzept
		await _navigationService.NavigateAsync<RoomDetailsViewModel>(("Room", item));
	}
}
