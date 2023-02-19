using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.DataContext.Configuration;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.HasKey(e => e.IdProvince).HasName("provincia_pkey");

        builder.ToTable("province");

        builder
            .Property(e => e.IdProvince)
            .HasDefaultValueSql("nextval('provincia_id_provincia_seq'::regclass)")
            .HasColumnName("id_province");
        builder.Property(e => e.Name).HasMaxLength(20).HasColumnName("name");
    }
}
