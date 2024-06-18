namespace RooME.Maui.Views;

public partial class RoomListPage : BasePage
{
	public RoomListPage(RoomListViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await (ViewModel as RoomListViewModel)!.LoadDataAsync();
	}
}
