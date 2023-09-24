using Api.Application.Authentication.Login;
using Carter;

namespace Api.Presentation.Endpoints.Authentication;

public class Login : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("login", Handle);
    }

    private async Task<IResult> Handle(LoginRequest request, ISender sender)
    {
        var query = new LoginQuery(
            request.Identifier,
            request.Password
        );

        var response = await sender.Send(query);
        return Results.Ok(response.Value);
    }

    public record LoginRequest(
        string Identifier,
        string Password
    );
}
