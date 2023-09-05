using Api.Application.Authentication.Services;
using Api.Infrastructure.Authentication;
using Api.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseInMemoryDatabase("appDb");
            //opt.UseSqlite("Database/app.db");
        });

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
