
using Api.Application.Common;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate.Entities;
using Api.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

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

    public static async Task<WebApplication> SeedDataAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        // Add default admin if there are no one
        bool exists = await context.Admins.AnyAsync();
        if (!exists)
        {
            Admin admin = Admin.CreateUnique("Admin", "Admin", Password.CreateNewPassword("string"), DateTime.Now.Year);
            await context.Admins.AddAsync(admin);
            await unitOfWork.SaveChangesAsync();
        }

        return app;
    }
}
