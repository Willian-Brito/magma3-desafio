using Magma3.API.Interfaces;
using Magma3.API.Repositories;
using Magma3.API.Services;

namespace Magma3.API.Configuration;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var mongoConnection = configuration.GetSection("MongoDB");
        services.Configure<MongoDB>(mongoConnection);
        
        services.AddHttpClient("Force1Api", client =>
        {
            client.BaseAddress = new Uri("https://api.magma-3.com");
        });
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IDocuSignService, DocuSignService>();
        services.AddScoped<IForce1Service, Force1Service>();
        services.AddScoped<IGoogleMapsService, GoogleMapsService>();
        services.AddScoped<IGraphService, GraphService>();
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}