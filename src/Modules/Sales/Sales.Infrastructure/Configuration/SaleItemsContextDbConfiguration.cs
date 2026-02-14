using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configuration;

internal class SaleItemsContextDbConfiguration : IEntityTypeConfiguration<SaleItems>
{
    public void Configure(EntityTypeBuilder<SaleItems> builder)
    {
        builder.ToTable("sale_items");
        builder.HasKey(si => si.SaleItemsId);
        builder.Property(si => si.SaleItemsId)
            .IsRequired()
            .HasColumnName("sale_items_id");
        builder.Property(si => si.ItemId)
            .IsRequired()
            .HasColumnName("item_id");
        builder.Property(si => si.SaleId)
            .IsRequired()
            .HasColumnName("sale_id");

        builder.HasOne(si => si.Item)
            .WithMany(i => i.SaleItems)
            .HasForeignKey(si => si.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(si => si.Sale)
            .WithMany(s => s.SaleItems)
            .HasForeignKey(si => si.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
