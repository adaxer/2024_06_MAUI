namespace RooME.Models;

public interface IRoomService
{
    Task<IEnumerable<Room>> GetRoomsAsync();
}
