using MediatR;

namespace Identity.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string UserName, string Email, string Password) : IRequest;

