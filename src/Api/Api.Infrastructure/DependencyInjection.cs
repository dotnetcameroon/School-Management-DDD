using Api.Application.Authentication.Services;
using Api.Infrastructure.Authentication;
using Api.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddPersistence();
        return services;
    }
}
