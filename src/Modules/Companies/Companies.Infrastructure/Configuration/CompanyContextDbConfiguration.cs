using Companies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Companies.Infrastructure.Configuration;

public class CompanyContextDbConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companies");
        builder.HasKey(c => c.CompanyId);
        builder.Property(c => c.CompanyId)
            .IsRequired()
            .HasColumnName("company_id");
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200).
            HasColumnName("name"); ;
        builder.Property(c => c.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()")
            .HasColumnName("created_at");
        builder.Property(c => c.IsActive)
            .IsRequired()
            .HasColumnName("is_active");
        builder.Property(c => c.UserId)
            .IsRequired()
            .HasColumnName("user_id");
    }
}
