using System.Reflection;
using Microsoft.OpenApi.Models;

namespace POS.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection service)
    {
        var openApi = new OpenApiInfo
        {
            Title = "Projecto Personal",
            Version = "v1",
            Description = "Punto de venta de viajes y hoteles",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "ECO23",
                Email = "chrismaquis@gmail.com",
                Url = new Uri("https://github.com/CoreDX1"),
            },
            License = new OpenApiLicense
            {
                Name = "MIT",
                Url = new Uri("https://github.com/CoreDX1"),
            }
        };
        service.AddSwaggerGen(x =>
        {
            openApi.Version = "v1";
            x.SwaggerDoc("v1", openApi);
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            x.IncludeXmlComments(xmlPath);
        });
        return service;
    }
}
