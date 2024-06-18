namespace RooME.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(RoomDetailsPage), typeof(RoomDetailsPage));
	}
}
