using Api.Domain.Common.Utilities;
using Api.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Presentation.Filters;

public class JwtAuthorizeFilterAttribute : AuthorizeAttribute, IActionFilter
{
    //private readonly JwtSettings _jwtSetting;
    public void OnActionExecuted(ActionExecutedContext context)
    {
        var success = context.HttpContext.Response.Headers.TryGetValue(Headers.Authentication, out var jwt);
        if (!success)
            return;

        //using 
        jwt = jwt.ToString()[7..].Trim();

        // Get the userId from the Token
        context.HttpContext.Response.Headers.Add(Headers.UserId, string.Empty);
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}
