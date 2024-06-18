namespace RooME.Maui.Interfaces;

public interface INavigationService
{
  Task NavigateAsync<T>(params (string key, object value)[] data) where T : BaseViewModel;

  Func<string, string> GetViewName { get; set; }
}
