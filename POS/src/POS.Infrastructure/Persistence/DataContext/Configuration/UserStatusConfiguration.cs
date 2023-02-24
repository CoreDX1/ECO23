using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.DataContext.Configuration;

public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
{
    public void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        builder.HasKey(e => e.IdUserStatus).HasName("user_status_pkey");

        builder.ToTable("user_status");

        builder.HasIndex(e => e.Status, "user_status_status_key").IsUnique();

        builder.Property(e => e.IdUserStatus).HasColumnName("id_user_status");
        builder.Property(e => e.Status).HasMaxLength(20).HasColumnName("status");
    }
}
