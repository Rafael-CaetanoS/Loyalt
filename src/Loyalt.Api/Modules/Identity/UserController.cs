using Identity.Application.Users.Commands.CreateUser;
using Identity.Application.Users.Queries.GetUserByEmail;
using Identity.Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loyalt.Api.Modules.Identity;

[ApiController]
[Route("users")]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var command = new CreateUserCommand(request.UserName, request.Email, request.Password);
        await _mediator.Send(command);
        return Created();
    }

    [HttpGet("email")]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        var query = new GetUserByEmailQuery(email);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetUserById([FromQuery] Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
