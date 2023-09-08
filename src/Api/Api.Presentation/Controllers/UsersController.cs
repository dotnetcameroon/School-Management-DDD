using Api.Application.UsersManagement.GetUsers;
using Api.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

public class UsersController : ApiController
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var query = new GetUsersQuery();
        var response = await _sender.Send(query);
        return Ok(response.Value);
    }
}
