using MediatR;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;

namespace Sales.Application.Items.Command.CreateItem;

internal class CreateItemCommandHandler(IItemRepository repository) : IRequestHandler<CreateItemCommand>
{
    public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var exist = await repository.ExistItemByCompanyAsync(request.Name, request.CompanyId, cancellationToken);
        var item = Item.CreateItem(request.Name, request.Price, request.CompanyId, exist);
        await repository.CreateItemAsync(item, cancellationToken);
    }
}