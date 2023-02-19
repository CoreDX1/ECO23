using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistence.DataContext;

public partial class Eco23Context : DbContext
{
    public Eco23Context(DbContextOptions<Eco23Context> options) : base(options) { }

    public virtual DbSet<UserEco> UserEcos { get; set; }
    public virtual DbSet<UserLocation> UserLocations { get; set; }
    public virtual DbSet<UserProfile> UserProfiles { get; set; }
    public virtual DbSet<UserPermission> UserPermissions { get; set; }
    public virtual DbSet<UserStatus> UserStatuses { get; set; }
    public virtual DbSet<Province> Provinces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
