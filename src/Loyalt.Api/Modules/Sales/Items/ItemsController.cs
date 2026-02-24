using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Items.Command.CreateItem;
using Sales.Application.Items.Command.UpdateItems;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] UpdateItemRequest request)
        {
            var command = new UpdateItemCommand(id, request.Name, request.Price);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}