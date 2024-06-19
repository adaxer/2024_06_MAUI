namespace RooME.Maui.Views;

public partial class RoomListPage : BasePage
{
	public RoomListPage(RoomListViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
        ViewModel.OnNavigatedTo();
	}
}
