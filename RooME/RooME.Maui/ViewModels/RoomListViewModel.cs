using RooME.Maui.Interfaces;

namespace RooME.Maui.ViewModels;

public partial class RoomListViewModel : BaseViewModel
{
	readonly SampleDataService _dataService;
  private readonly INavigationService _navigationService;
  [ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ObservableCollection<SampleItem>? items;

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
		if (Items is null)
		{
			return;
		}

		var moreItems = await _dataService.GetItems();

		foreach (var item in moreItems)
		{
			Items.Add(item);
		}
	}

	public async Task LoadDataAsync()
	{
		Items = new ObservableCollection<SampleItem>(await _dataService.GetItems());
	}

	[RelayCommand]
	private async Task GoToDetailsAsync(SampleItem item)
	{
		// Zielkonzept
		await _navigationService.NavigateAsync<RoomDetailsViewModel>(("Room", item));
	}
}
