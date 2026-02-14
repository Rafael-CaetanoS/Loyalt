using Sales.Domain.Entities;

namespace Sales.Domain.Repositories;

public interface IItemsSaleRepository
{
    public Task AddItemsSaleAsync(List<SaleItems> saleItems, CancellationToken cancellationToken);
    public Task<List<SaleItems>> GetAllItemsSaleBySaleIdAsync(int saleId, CancellationToken cancellationToken);
}