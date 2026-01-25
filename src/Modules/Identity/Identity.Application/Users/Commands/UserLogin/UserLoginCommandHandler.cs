using Identity.Application.Users.Services;
using MediatR;

namespace Identity.Application.Users.Commands.UserLogin;

internal class UserLoginCommandHandler(IAuthService auth) : IRequestHandler<UserLoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var isValid = await auth.VerifyPasswordAsync(request.Email, request.Password);
        if (!isValid)
            throw new UnauthorizedAccessException("Email ou senha inválidos");

        var token = await auth.GenerateTokenAsync(request.Email, request.Password);
        return new LoginResponse(token);
    }
}
