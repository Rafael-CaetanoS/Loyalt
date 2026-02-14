using Companies.Domain.Entities;
using Companies.Domain.Repositories;
using Companies.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Companies.Infrastructure.Repositories;

public class CompanyRepository(CompanyContext context) : ICompanyRepository
{
    public async Task AddAsync(Company company)
    {
        await context.Companies.AddAsync(company);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string Name) =>
         await context.Companies.AnyAsync(c => c.Name == Name);

    public async Task<List<Company>> GetAllAsync() =>
        await context.Companies.Where(x => x.IsActive == true).ToListAsync();

    public Task<Company?> GetByIdAsync(Guid companyId) =>
        context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);

    public async Task UpdateAsync(Company company)
    {
       context.Companies.Update(company);
       await context.SaveChangesAsync();
    }
}
