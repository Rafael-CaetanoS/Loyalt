using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Items.Command.CreateItem;

namespace Loyalt.Api.Modules.Sales.Items
{
    [Route("items")]
    [ApiController]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateItemRequest request)
        {
            var command = new CreateItemCommand(request.Name, request.Price, request.CompanyId);
            await _mediator.Send(command);
            return Created();
        }
    }
}