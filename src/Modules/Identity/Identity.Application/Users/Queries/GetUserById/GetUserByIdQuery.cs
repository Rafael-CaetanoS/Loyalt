using MediatR;

namespace Identity.Application.Users.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid userId) : IRequest<UserDto>;
