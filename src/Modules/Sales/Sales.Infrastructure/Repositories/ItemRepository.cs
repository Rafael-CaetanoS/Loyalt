using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Repositories;
using Sales.Infrastructure.Context;

namespace Sales.Infrastructure.Repositories;

public class ItemRepository(SalesContext context) : IItemRepository
{
    public async Task CreateItemAsync(Item item, CancellationToken cancellationToken)
    {
        context.Item.Add(item);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistItemByCompanyAsync(string name, Guid companyId, CancellationToken cancellationToken) =>
        await  context.Item.AnyAsync(i => i.Name == name && i.Company == companyId, cancellationToken);

    public async Task<List<Item>> GetAllItemsByCompanyAsync(Guid companyId, CancellationToken cancellationToken) =>
        await context.Item.Where(i => i.Company == companyId).ToListAsync(cancellationToken);

    public async Task<Item> GetItemByIdAsync(int id, CancellationToken cancellationToken) =>
        await context.Item.FirstOrDefaultAsync(i => i.ItemId == id, cancellationToken) ?? null!; 

    public async Task<List<Item>> GetItemsIsActiveByCompanyAsync(Guid companyId, CancellationToken cancellationToken) => 
        await context.Item.Where(i => i.Company == companyId && i.IsActive).ToListAsync(cancellationToken);

    public async Task UpdateItemAsync(Item item, CancellationToken cancellationToken)
    {
        context.Item.Update(item);
        await context.SaveChangesAsync(cancellationToken);
    }
}