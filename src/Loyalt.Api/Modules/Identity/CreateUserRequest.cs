namespace Loyalt.Api.Modules.Identity;

public sealed record CreateUserRequest(string UserName, string Email, string Password);