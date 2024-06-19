namespace RooME.Contracts;

public interface IRoomService
{
    Task<IEnumerable<Room>> GetRoomsAsync();
}
