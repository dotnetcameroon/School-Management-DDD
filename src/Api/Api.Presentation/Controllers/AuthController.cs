using Api.Application.Authentication.Login;
using Api.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Presentation.Controllers;

public class AuthController : ApiController
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginQuery query)
    {
        var response = await _sender.Send(query);
        return Ok(response.IsSuccess ? response.Value : response.Errors.First().Message);
    }
}
