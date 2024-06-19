
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel.Communication;
using RooME.Contracts;

namespace RooME.Maui.Services;
public class MauiUserService : IUserService
{
    private readonly HttpClient _client;
    private readonly ILogger<MauiUserService> _logger;
    private UserInfo _userInfo = default!;

    public MauiUserService(HttpClient client, ILogger<MauiUserService> logger)
    {
        _client = client;
        _logger = logger;
        // UserInfo laden
    }

    public string? Email => _userInfo?.Email;

    public UserInfo? UserInfo => _userInfo;

    public async Task<bool> GetIsLoggedInAsync()
    {
        if (_userInfo == null)
        {
            if (await TryLoadUserInfoAsync() == false)
            {
                return false;
            }
        }
        if (!string.IsNullOrEmpty(_userInfo?.AccessToken))
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userInfo?.AccessToken);
            var response = await _client.GetAsync($"{_client.BaseAddress}hello");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }

        if (!string.IsNullOrEmpty(_userInfo?.RefreshToken))
        {
            var response = await _client.PostAsJsonAsync<RefreshInfo>($"{_client.BaseAddress}refresh", new RefreshInfo(_userInfo.RefreshToken));
            return await TryGetUserInfoAsync(_userInfo.Email!, response);
        }

        return false;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        try
        {
            var url = $"{_client.BaseAddress}login?useCookies=false";
            var response = await _client.PostAsJsonAsync<LoginInfo>(url, new LoginInfo(email, password));
            await TryGetUserInfoAsync(email, response);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login failed");
            return false;
        }
    }

    private async Task<bool> TryGetUserInfoAsync(string email, HttpResponseMessage response)
    {
        try
        {
            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _userInfo = new UserInfo { AccessToken = tokenResponse?.AccessToken, Email = email, RefreshToken = tokenResponse?.RefreshToken };
            await SaveUserInfoAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task SaveUserInfoAsync()
    {
        await SecureStorage.SetAsync("Email", _userInfo.Email!);
        await SecureStorage.SetAsync("AccessToken", _userInfo.AccessToken!);
        await SecureStorage.SetAsync("RefreshToken", _userInfo.RefreshToken!);
    }

    private async Task<bool> TryLoadUserInfoAsync()
    {
        var email = await SecureStorage.GetAsync("Email");
        var accessToken = await SecureStorage.GetAsync("AccessToken");
        var refreshToken = await SecureStorage.GetAsync("RefreshToken");
        if (email != null && accessToken != null && refreshToken != null)
        {
            _userInfo = new UserInfo { Email = email, AccessToken = accessToken, RefreshToken = refreshToken };
            return true;
        }
        return false;
    }

    public record LoginInfo(string email, string password);
    public record RefreshInfo(string refreshToken);
}
