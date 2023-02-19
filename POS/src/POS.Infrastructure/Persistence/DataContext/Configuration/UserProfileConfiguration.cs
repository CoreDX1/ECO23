using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.DataContext.Configuration;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(e => e.IdUserProfile).HasName("user_profile_pkey");

        builder.ToTable("user_profile");

        builder.Property(e => e.IdUserProfile).HasColumnName("id_user_profile");
        builder
            .Property(e => e.CreationDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("creation_date");
        builder.Property(e => e.Email).HasMaxLength(30).HasColumnName("email");
        builder.Property(e => e.IdLocation).HasColumnName("id_location");
        builder.Property(e => e.IdUser).HasColumnName("id_user");
        builder.Property(e => e.UserPassword).HasMaxLength(10).HasColumnName("user_password");

        builder
            .HasOne(d => d.IdLocationNavigation)
            .WithMany(p => p.UserProfiles)
            .HasForeignKey(d => d.IdLocation)
            .HasConstraintName("user_profile_id_location_fkey");

        builder
            .HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.UserProfiles)
            .HasForeignKey(d => d.IdUser)
            .HasConstraintName("user_profile_id_user_fkey");
    }
}
