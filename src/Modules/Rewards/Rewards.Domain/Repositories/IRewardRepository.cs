using Rewards.Domain.Entities;

namespace Rewards.Domain.Repositories;

public interface IRewardRepository
{
    public Task AddAsync(Reward reward);
    public Task UpdateAsync(Reward reward);
    public Task DeleteAsync(Reward reward);
    public Task<List<Reward>> GetAllByCompanyIdAsync(Guid companyId);
    public Task<Reward?> GetByIdAsync(int rewardId);
}
