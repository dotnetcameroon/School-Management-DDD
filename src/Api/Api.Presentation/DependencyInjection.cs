
namespace Api.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication()
            .AddJwtBearer(opt =>
            {
                opt.Audience = "";
                opt.ClaimsIssuer = "";
                opt.Validate();
            });

        return services;
    }
}
