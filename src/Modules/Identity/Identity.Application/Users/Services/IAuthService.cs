namespace Identity.Application.Users.Services;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(string username, string password);
    Task<bool> VerifyPasswordAsync(string username, string password);
}
