using Api.Application.Authentication.Login;
using Api.Application.Authentication.Register;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
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

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response.IsSuccess ? response.Value : response.Errors.First().Message);
    }
}
