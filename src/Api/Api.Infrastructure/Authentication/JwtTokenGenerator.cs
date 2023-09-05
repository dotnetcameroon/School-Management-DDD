using System.Security.Claims;
using Api.Application.Authentication.Services;

namespace Api.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(IEnumerable<Claim> claims)
    {
        return "token";
    }
}
