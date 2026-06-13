using Microsoft.OpenApi.Models;

namespace Magma3.API.Configuration;

public static class DependencyInjectionSwagger
{
    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo 
            { 
                Title = "Magma3 - API", 
                Description = "Desenvolvido por Willian Brito",
                Version = "v1",
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });

        return services;
    }
}