using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sales.Infrastructure.Context;

internal class SalesContextFactory : IDesignTimeDbContextFactory<SalesContext>
{
    public SalesContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SalesContext>();
        optionsBuilder.UseNpgsql(args[0]);
        return new SalesContext(optionsBuilder.Options);
    }
}
 