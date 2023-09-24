using Api.Application.StudentsManagement.Registration;
using Api.Domain.AcademicAggregate.Enums;
using Api.Domain.Common.Utilities;
using Api.Presentation.Utilities;
using Carter;

namespace Api.Presentation.Endpoints.Students;

public class RegisterStudent : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app
            .MapPost("students", Handle)
            .RequireAuthorization(Policies.AdminOnly);
    }

    private async Task<IResult> Handle(HttpContext context, RegisterStudentRequest request, ISender sender)
    {
        string adminId = AuthHeaders.GetUserId(context.Request.Headers);
        var command = new RegisterStudentCommand(
            adminId,
            request.FirstName,
            request.LastName,
            request.Password,
            request.DateOfBirth,
            request.Level,
            request.Year,
            (Specialization)request.Specialization
        );

        var response = await sender.Send(command);
        if (response.IsFailed)
            return Results.BadRequest(response.Errors.First());
        return Results.Ok(response.Value);
    }

    public record RegisterStudentRequest(
        string? FirstName,
        string LastName,
        string Password,
        DateTime DateOfBirth,
        int Level,
        int Year,
        int Specialization);
}
