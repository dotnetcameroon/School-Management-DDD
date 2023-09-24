using Api.Application.UsersManagement.GetUsers;
using Carter;

namespace Api.Presentation.Endpoints.Users;

public class GetUsers : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("users", Handle);
    }

    private async Task<IResult> Handle(ISender sender)
    {
        var query = new GetUsersQuery();
        var response = await sender.Send(query);
        return Results.Ok(response.Value);
    }
}
