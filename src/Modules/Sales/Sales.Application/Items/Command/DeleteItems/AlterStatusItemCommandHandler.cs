using MediatR;
using Sales.Domain.Repositories;

namespace Sales.Application.Items.Command.DeleteItems;

internal class AlterStatusItemCommandHandler(IItemRepository itemRepository) : IRequestHandler<AlterStatusItemCommand>
{
    public async Task Handle(AlterStatusItemCommand request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetItemByIdAsync(request.ItemId, cancellationToken);
        if (item is null)
        {
            throw new Exception("Item not found");
        }
        
        item.AlterStatus();
        await itemRepository.UpdateItemAsync(item, cancellationToken);
    }
}
