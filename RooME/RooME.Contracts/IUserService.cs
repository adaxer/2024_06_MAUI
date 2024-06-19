namespace RooME.Contracts;
public interface IUserService
{
    Task<bool> LoginAsync(string email, string password);

    Task<bool> GetIsLoggedInAsync();

    string? Email { get;  }
    UserInfo? UserInfo { get; }
}
