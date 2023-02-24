using System.Reflection;
using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Persistence.DataContext.Configuration;

namespace POS.Infrastructure.Persistence.DataContext;

public partial class Eco23Context : DbContext
{
    public Eco23Context(DbContextOptions<Eco23Context> options) : base(options) { }

    public virtual DbSet<UserEco> UserEco { get; set; }
    public virtual DbSet<UserLocation> UserLocation { get; set; }
    public virtual DbSet<UserProfile> UserProfile { get; set; }
    public virtual DbSet<UserPermission> UserPermission { get; set; }
    public virtual DbSet<UserStatus> UserStatuse { get; set; }
    public virtual DbSet<Province> Province { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
