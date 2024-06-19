namespace RooME.Maui.ViewModels;

public partial class RoomDetailsViewModel : BaseViewModel
{
	[ObservableProperty]
	Room? room;

    public override void OnNavigatedTo(IDictionary<string, object> data)
    {
        if (data.TryGetValue(nameof(Room), out var item) && item is Room sampleItem)
        {
            Room = sampleItem;
        }
    }

    [RelayCommand]
    private void BookRoom()
    {

    }
}
