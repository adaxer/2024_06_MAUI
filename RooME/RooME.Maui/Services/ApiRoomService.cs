
using System.Net.Http.Headers;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace RooME.Maui.Services;
public class ApiRoomService : IRoomService
{
    private readonly IUserService _userService;
    private readonly HttpClient _client;
    private readonly IMessenger _messenger;
    private readonly ILocalizationService _localizationService;

    public ApiRoomService(IUserService userService, HttpClient client, IMessenger messenger, ILocalizationService localizationService)
    {
        _userService = userService;
        _client = client;
        _messenger = messenger;
        _localizationService = localizationService;
    }

    public async Task<IEnumerable<Room>> GetRoomsAsync()
    {
        if(!await _userService.GetIsLoggedInAsync())
        {
            _messenger.Send(new StatusMessage(_localizationService.Get("UI_User_PleaseLogin")));
            return new List<Room>();
        }

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userService.UserInfo?.AccessToken);
        var result = await _client.GetFromJsonAsync<IEnumerable<Room>>($"{_client.BaseAddress}rooms");
        return result!;
    }
}
