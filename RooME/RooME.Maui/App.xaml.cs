namespace RooME.Maui;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    private IStatusService _statusService;

    public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		MainPage = new AppShell();
        _serviceProvider = serviceProvider;
        _statusService = serviceProvider.GetRequiredService<IStatusService>();
    }
}
