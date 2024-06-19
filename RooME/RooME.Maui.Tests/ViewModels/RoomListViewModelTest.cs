using NSubstitute;
using RooME.Maui.Interfaces;
using RooME.Maui.ViewModels;
using RooME.Models;

namespace RooME.Maui.Tests.ViewModels;

public class RoomListViewModelTest
{
    [Fact] 
    public async Task LoadDataAsync_Calls_RoomService()
    {
        // Arrange
        var roomService = Substitute.For<IRoomService>();
        roomService.GetRoomsAsync().Returns(new List<Room>());
        var viewModel = new RoomListViewModel(roomService, Substitute.For<INavigationService>());

        // Act
        await viewModel.LoadDataAsync();

        // Assert
        await roomService.Received(1).GetRoomsAsync();
    }
}
