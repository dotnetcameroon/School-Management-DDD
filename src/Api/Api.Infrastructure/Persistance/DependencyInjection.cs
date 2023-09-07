using Api.Application.Repositories;
using Api.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        //services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddDbContext<AppDbContext>(opt =>
        {
            //opt.UseInMemoryDatabase("appDb");
            opt.UseSqlite("Data Source=Database/app.db");
        });

        return services;
    }
}
