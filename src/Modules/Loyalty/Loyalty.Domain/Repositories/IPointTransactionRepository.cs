
using Loyalty.Domain.Entities;

namespace Loyalty.Domain.Repositories;

public interface IPointTransactionRepository
{
    public Task AddAsync(PointTransaction pointTransaction);
}
