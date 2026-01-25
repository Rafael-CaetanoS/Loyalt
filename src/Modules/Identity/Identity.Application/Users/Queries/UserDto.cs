namespace Identity.Application.Users.Queries;

public sealed record UserDto(Guid UserId, string Name, string Email, bool IsActive);
