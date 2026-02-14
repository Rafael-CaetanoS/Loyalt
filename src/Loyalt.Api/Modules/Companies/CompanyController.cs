using Companies.Application.Companies.Command.CreateCompany;
using Companies.Application.Companies.Command.UpdateCompany;
using Companies.Application.Companies.Queries.GetAllCompanies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var query = new GetAllCompaniesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyRequest request)
    {
        var command = new UpdateCompanyCommand(request.CompanyId, request.Name);
        await _mediator.Send(command);
        return NoContent();
    }
}

