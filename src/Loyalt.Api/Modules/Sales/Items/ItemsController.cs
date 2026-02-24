using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Items.Command.CreateItem;
using Sales.Application.Items.Command.DeleteItems;
using Sales.Application.Items.Command.UpdateItems;
using Sales.Application.Items.Queries.GetItemsIsActiveByCompany;

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
        
        [HttpGet("company")]
        public async Task<IActionResult> GetItemsIsActiveByCompany([FromQuery]Guid companyId)
        {
            var query = new GetItemsIsActiveByCompanyQuery(companyId);
            var items = await _mediator.Send(query);
            return Ok(items);
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

        [HttpPut("{id}/status")]
        public async Task<IActionResult> AlterStatusItem(int id)
        {
            var command = new AlterStatusItemCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}