using Companies.Application.Companies.Command.CreateCompany;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Loyalt.Api.Modules.Companies;


[Authorize]
[ApiController]
[Route("companies")]
public class CompanyController : Controller
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var command = new CreateCompanyCommand(request.Name, Guid.Parse(userId!));
        await _mediator.Send(command);
        return Created();
    }
}

