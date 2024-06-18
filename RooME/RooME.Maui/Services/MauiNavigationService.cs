using RooME.Maui.Interfaces;

namespace RooME.Maui.Services;
public class MauiNavigationService : INavigationService
{
    public MauiNavigationService()
    {
        GetViewName = GetViewNameDefault;
    }

    public Func<string, string> GetViewName
    {
        get;
        set;
    }

    private string GetViewNameDefault(string targetName)
    {
        return targetName.Replace("ViewModel", "Page");
    }

    public async Task NavigateAsync<T>(params (string key, object value)[] data) where T : BaseViewModel
    {
        var pageName = GetViewName(typeof(T).Name);
        var parameters = data.ToDictionary(kv => kv.key, kv => kv.value);
        await Shell.Current.GoToAsync(pageName, true, parameters);
    }
}
