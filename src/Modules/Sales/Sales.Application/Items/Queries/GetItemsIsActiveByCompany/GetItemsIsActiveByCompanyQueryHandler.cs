using MediatR;
using Sales.Domain.Repositories;

namespace Sales.Application.Items.Queries.GetItemsIsActiveByCompany;

internal class GetItemsIsActiveByCompanyQueryHandler(IItemRepository itemRepository)
 : IRequestHandler<GetItemsIsActiveByCompanyQuery, List<ItemIsActiveByCompanyResponse>>
{
    public async Task<List<ItemIsActiveByCompanyResponse>> Handle(GetItemsIsActiveByCompanyQuery request, CancellationToken cancellationToken)
    {
        var items = await itemRepository.GetItemsIsActiveByCompanyAsync(request.CompanyId, cancellationToken);
        if(items is null)
            return [];
            
        return items.Select(i => new ItemIsActiveByCompanyResponse(i.ItemId, i.Name, i.Price)).ToList();
    }   
}