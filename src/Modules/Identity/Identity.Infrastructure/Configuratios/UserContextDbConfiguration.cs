using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Configuratios;

public class UserContextDbConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserId)
            .IsRequired()
            .HasColumnName("user_id");
        builder.Property(u => u.UserName)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("user_name");
        builder.Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnName("email");
        builder.Property(u => u.PasswordHash)
            .HasMaxLength(500)
            .IsRequired()
            .HasColumnName("password_hash");
        builder.Property(u => u.IsActive)
            .IsRequired()
            .HasColumnName("is_active");
        builder.Property(u => u.CreatedAt)
            .IsRequired();
    }
}
