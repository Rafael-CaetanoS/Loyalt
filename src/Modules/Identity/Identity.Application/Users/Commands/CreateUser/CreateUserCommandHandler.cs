using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using MediatR;

namespace Identity.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existUser = await repository.IsEmailTakenAsync(request.Email);
        var user = User.Create(request.UserName, request.Email, request.Password, DateTime.UtcNow, existUser);
        await repository.AddUserAsync(user);
    }
}
