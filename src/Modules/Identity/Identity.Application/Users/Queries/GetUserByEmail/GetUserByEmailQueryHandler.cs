using Identity.Domain.Repositories;
using MediatR;

namespace Identity.Application.Users.Queries.GetUserByEmail;

internal class GetUserByEmailQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserByEmailAsync(request.Email);
        if (user is null)
        {
            throw new KeyNotFoundException($"User with email '{request.Email}' was not found.");
        }

        return new UserDto
        (
            user.UserId,
            user.UserName,
            user.Email,
            user.IsActive
        );
    }
}
