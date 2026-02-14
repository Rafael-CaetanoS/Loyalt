using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.Configuration;

internal class ItemContextDbConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("items");
        builder.HasKey(i => i.ItemId);
        builder.Property(i => i.ItemId)
            .IsRequired()
            .HasColumnName("item_id");
        builder.Property(i => i.Name) 
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("name");
        builder.Property(i => i.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)")
            .HasColumnName("price");
        builder.Property(i=> i.Company)
            .IsRequired()
            .HasColumnName("company");
        builder.Property(i => i.Created)
            .IsRequired()
            .HasColumnName("created");
        builder.Property(i => i.Updated)
            .HasColumnName("updated");
        builder.Property(i => i.IsActive)
            .IsRequired()
            .HasColumnName("is_active");
    }
}