using Api.Application.Authentication.Services;
using Api.Infrastructure.Authentication;
using Api.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddPersistence();
        services.AddAuth(cfg);
        return services;
    }
}
