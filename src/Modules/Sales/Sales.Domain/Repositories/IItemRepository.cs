using Sales.Domain.Entities;

namespace Sales.Domain.Repositories;

public interface IItemRepository
{
    public Task CreateItemAsync(Item item, CancellationToken cancellationToken);
    public Task UpdateItemAsync(Item item, CancellationToken cancellationToken);
    public Task<List<Item>> GetItemsIsActiveByCompanyAsync(Guid companyId, CancellationToken cancellationToken);
    public Task<List<Item>> GetAllItemsByCompanyAsync(Guid companyId, CancellationToken cancellationToken);
    public Task<bool> ExistItemByCompanyAsync(string name, Guid companyId, CancellationToken cancellationToken);
    public Task<Item> GetItemByIdAsync(int id, CancellationToken cancellationToken);
}