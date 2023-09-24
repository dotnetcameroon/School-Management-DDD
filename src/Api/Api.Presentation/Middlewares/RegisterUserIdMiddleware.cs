
using System.Security.Claims;
using Api.Domain.Common.Utilities;

namespace Api.Presentation.Middlewares;

public class RegisterUserIdMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Before
        Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        string userId = userIdClaim is null ? string.Empty : userIdClaim.Value;
        context.Request.Headers.TryAdd(Headers.UserId, userId);

        await next(context);
        // After
    }
}
