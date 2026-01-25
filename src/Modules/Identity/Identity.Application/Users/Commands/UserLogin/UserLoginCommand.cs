using MediatR;

namespace Identity.Application.Users.Commands.UserLogin;

public sealed record UserLoginCommand(string Email, string Password) : IRequest<LoginResponse>;
