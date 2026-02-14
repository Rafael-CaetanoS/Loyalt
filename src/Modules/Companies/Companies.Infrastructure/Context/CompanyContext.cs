using Companies.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Companies.Infrastructure.Context;

public class CompanyContext : DbContext
{
	public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

	public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
