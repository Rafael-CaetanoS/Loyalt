using Sales.Domain.Entities;

namespace Sales.Domain.Repositories;

public interface ISaleRepository
{
    public Task AddSaleAsync(Sale sale, CancellationToken cancellationToken);
    public Task<Sale> GetSaleByIdAsync(int id, CancellationToken cancellationToken);
    public Task<List<Sale>> GetAllSalesByCompanyIdAsync(Guid companyId, CancellationToken cancellationToken);
    public Task<List<Sale>> GetAllSalesByClientIdAsync(Guid clientId, CancellationToken cancellationToken);
}