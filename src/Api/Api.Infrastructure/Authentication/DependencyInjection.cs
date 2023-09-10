using System.Text;
using Api.Domain.Common.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Api.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                JwtSettings jwtSettings = cfg.GetRequiredSection(JwtSettings.SectionName).Get<JwtSettings>()!;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(Policies.AdminOnly, p => p.RequireRole(Roles.Admin));
            opt.AddPolicy(Policies.TeacherOnly, p => p.RequireRole(Roles.Teacher));
            opt.AddPolicy(Policies.TeachersAndStudentsOnly, p => p.RequireRole(Roles.Teacher, Roles.Student));
        });

        return services;
    }
}
