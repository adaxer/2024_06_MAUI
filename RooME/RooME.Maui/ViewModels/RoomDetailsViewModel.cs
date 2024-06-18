
namespace RooME.Maui.ViewModels;

public partial class RoomDetailsViewModel : BaseViewModel
{
	[ObservableProperty]
	SampleItem? room;

    public override void OnNavigatedTo(IDictionary<string, object> data)
    {
        if (data.TryGetValue(nameof(Room), out var item) && item is SampleItem sampleItem)
        {
            Room = sampleItem;
        }
    }
}
