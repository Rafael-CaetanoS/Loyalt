using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Companies.Infrastructure.Context;

public class CompanyContextFactory : IDesignTimeDbContextFactory<CompanyContext>
{
    public CompanyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CompanyContext>();
        optionsBuilder.UseNpgsql(args[0]);
        return new CompanyContext(optionsBuilder.Options);
    }
}
