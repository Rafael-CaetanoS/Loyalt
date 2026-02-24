using MediatR;
using Sales.Domain.Repositories;

namespace Sales.Application.Items.Command.UpdateItems;

internal sealed class UpdateItemCommandHandler(IItemRepository itemRepository) : IRequestHandler<UpdateItemCommand>
{
    public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item  = await itemRepository.GetItemByIdAsync(request.ItemId, cancellationToken);
        if (item is null)
        {
            throw new Exception("Item not found");
        }
        item.UpdateItem(request.Name, request.Price);
        await itemRepository.UpdateItemAsync(item, cancellationToken);
    }
}