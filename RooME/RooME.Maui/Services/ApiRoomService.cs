
using System.Net.Http.Json;

namespace RooME.Maui.Services;
public class ApiRoomService : IRoomService
{
    public async Task<IEnumerable<Room>> GetRoomsAsync()
    {
        HttpClient client = new HttpClient();
        var result = await client.GetFromJsonAsync<IEnumerable<Room>>("https://localhost:7195/rooms");
        return result!;
    }
}
