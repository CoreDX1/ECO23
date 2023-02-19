using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.Persistence.DataContext;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Infrastructure.Persistence.Repositories;

namespace POS.Infrastructure.Persistence.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var assembly = typeof(Eco23Context).Assembly.FullName;
        services.AddDbContext<Eco23Context>(
            options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("POSConnectionString"),
                    b => b.MigrationsAssembly(assembly)
                ),
            ServiceLifetime.Transient
        );
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
