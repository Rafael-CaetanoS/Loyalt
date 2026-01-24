using Companies.Domain.Entities;

namespace Companies.Domain.Repositories;

public interface ICompanyRepository
{
    public Task<bool> ExistsAsync(string Name);
    public Task AddAsync(Company company);
    public Task UpdateAsync(Company company);
    public  Task<List<Company>> GetAllAsync();
    public Task<Company?> GetByIdAsync(Guid companyId);
}
