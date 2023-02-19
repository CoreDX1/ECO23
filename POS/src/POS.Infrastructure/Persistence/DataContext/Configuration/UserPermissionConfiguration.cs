using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.DataContext.Configuration;

public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.HasKey(e => e.IdUserPermission).HasName("user_permission_pkey");

        builder.ToTable("user_permission");

        builder.Property(e => e.IdUserPermission).HasColumnName("id_user_permission");
        builder.Property(e => e.IdUserEco).HasColumnName("id_user_eco");
        builder.Property(e => e.IdUserStatus).HasColumnName("id_user_status");

        builder
            .HasOne(d => d.IdUserEcoNavigation)
            .WithMany(p => p.UserPermissions)
            .HasForeignKey(d => d.IdUserEco)
            .HasConstraintName("user_permission_id_user_eco_fkey1");

        builder
            .HasOne(d => d.IdUserStatusNavigation)
            .WithMany(p => p.UserPermissions)
            .HasForeignKey(d => d.IdUserStatus)
            .HasConstraintName("user_permission_id_user_status_fkey1");
    }
}
