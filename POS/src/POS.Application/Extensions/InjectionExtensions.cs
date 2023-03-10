using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.DTO.Request;
using POS.Application.Interfaces;
using POS.Application.Services;
using POS.Application.Validators;

namespace POS.Application.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionApplication(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton(configuration);
        services.AddScoped<IValidator<UserEcoRequestDto>, UserValidatorRules>();
        services.AddScoped<IUserEcoApplication, UserEcoApplication>();
        services.AddScoped<IUserLocationApplication, UserLocationApplication>();
        services.AddScoped<IUserProfileApplication, UserProfileApplication>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
