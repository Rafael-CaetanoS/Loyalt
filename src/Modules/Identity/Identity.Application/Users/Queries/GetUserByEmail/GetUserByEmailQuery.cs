using MediatR;

namespace Identity.Application.Users.Queries.GetUserByEmail;

public sealed record GetUserByEmailQuery(string Email) : IRequest<UserDto>;
