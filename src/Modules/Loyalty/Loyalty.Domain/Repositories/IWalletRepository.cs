using Loyalty.Domain.Entities;

namespace Loyalty.Domain.Repositories;

public interface IWalletRepository
{
    public Task AddAsync(Wallet wallet);
    public Task UpdateAsync(Wallet wallet);
    public Task<bool> ExistsAsync(Guid userId, Guid companyId);
    public Task<Wallet?> GetByUserAndCompanyIdAsync(Guid userId, Guid companyId);
}
