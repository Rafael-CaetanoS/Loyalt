using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configuration;

internal class SaleContextDbConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("sales");
        builder.HasKey(s => s.SaleId);
        builder.Property(s => s.SaleId)
            .IsRequired()
            .HasColumnName("sale_id");
        builder.Property(s => s.Company)
            .IsRequired()
            .HasColumnName("company");
        builder.Property(s => s.ClientId)
            .IsRequired()
            .HasColumnName("client_id");
        builder.Property(s => s.Employee)
            .IsRequired()
            .HasColumnName("employee");
        builder.Property(s => s.Price)
            .IsRequired()
            .HasColumnType("numeric(18,2)")
            .HasColumnName("price");
        builder.Property(s => s.CreatedData)
            .IsRequired()
            .HasColumnName("created_data");
        builder.Property(s => s.IsActive)
            .IsRequired()
            .HasColumnName("is_active");
        builder.Property(s => s.ItemsCount)
            .IsRequired()
            .HasColumnName("items_count");

        builder.HasMany(s => s.SaleItems)
            .WithOne(si => si.Sale)
            .HasForeignKey(si => si.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
