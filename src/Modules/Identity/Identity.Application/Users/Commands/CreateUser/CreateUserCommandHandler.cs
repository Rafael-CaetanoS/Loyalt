using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using MediatR;

namespace Identity.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await repository.IsEmailTakenAsync(request.Email);
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = User.Create(request.UserName, request.Email, passwordHash, DateTime.UtcNow, existUser);
        await repository.AddUserAsync(user);
    }
}
