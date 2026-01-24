using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Context;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
