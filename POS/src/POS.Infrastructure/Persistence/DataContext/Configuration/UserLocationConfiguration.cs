using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.DataContext.Configuration;

public class UserLocationConfiguration : IEntityTypeConfiguration<UserLocation>
{
    public void Configure(EntityTypeBuilder<UserLocation> builder)
    {
        builder.HasKey(e => e.Id).HasName("user_location_pkey");

        builder.ToTable("user_location");

        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("nextval('localidad_id_localidad_seq'::regclass)")
            .HasColumnName("id_location");
        builder.Property(e => e.HouseNumber).HasColumnName("house_number");
        builder.Property(e => e.IdProvince).HasColumnName("id_province");
        builder.Property(e => e.Street).HasMaxLength(20).HasColumnName("street");

        builder
            .HasOne(d => d.IdProvinceNavigation)
            .WithMany(p => p.UserLocations)
            .HasForeignKey(d => d.IdProvince)
            .HasConstraintName("user_location_id_province_fkey");
    }
}
