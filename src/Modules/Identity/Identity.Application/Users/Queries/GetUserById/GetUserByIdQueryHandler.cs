using Identity.Domain.Repositories;
using MediatR;

namespace Identity.Application.Users.Queries.GetUserById;

internal class GetUserByIdQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetUserByIdAsync(request.userId);
        if (user is null)
        {
            throw new KeyNotFoundException($"User with ID {request.userId} was not found.");
        }
        return new UserDto(user.UserId, user.UserName, user.Email, user.IsActive);
    }
}
