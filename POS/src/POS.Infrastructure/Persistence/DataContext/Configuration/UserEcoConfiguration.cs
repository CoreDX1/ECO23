using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.DataContext.Configuration;

public class UserEcoConfiguration : IEntityTypeConfiguration<UserEco>
{
    public void Configure(EntityTypeBuilder<UserEco> builder)
    {
        builder.HasKey(e => e.IdUser).HasName("user_eco_pkey");

        builder.ToTable("user_eco");

        builder.Property(e => e.IdUser).HasColumnName("id_user");
        builder.Property(e => e.CellPhone).HasMaxLength(10).HasColumnName("cell_phone");
        builder
            .Property(e => e.MaternalLastName)
            .HasMaxLength(20)
            .HasColumnName("maternal_last_name");
        builder.Property(e => e.Name).HasMaxLength(20).HasColumnName("name");
        builder
            .Property(e => e.PaternalLastName)
            .HasMaxLength(20)
            .HasColumnName("paternal_last_name");
    }
}
