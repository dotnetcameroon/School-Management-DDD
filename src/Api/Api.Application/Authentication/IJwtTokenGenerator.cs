using System.Security.Claims;

namespace Api.Application.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}
