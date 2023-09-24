using Api.Application.TeachersManagement.Registration;
using Api.Domain.Common.Utilities;
using Api.Presentation.Utilities;
using Carter;

namespace Api.Presentation.Endpoints.Teachers;

public class RegisterTeacher : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapPost("teachers", Handle)
            .RequireAuthorization(Policies.AdminOnly);
    }

    private async Task<IResult> Handle(HttpContext context, RegisterTeacherRequest request, ISender sender)
    {
        var userId = AuthHeaders.GetUserId(context.Request.Headers);
        var command = new RegisterTeacherCommand(userId, request.FirstName, request.LastName, request.Password);
        var response = await sender.Send(command);
        return Results.Ok(response.Value);
    }

    public record RegisterTeacherRequest(
        string? FirstName,
        string LastName,
        string Password);
}
