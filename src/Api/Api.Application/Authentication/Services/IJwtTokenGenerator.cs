using System.Security.Claims;

namespace Api.Application.Authentication.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}
