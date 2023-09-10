using Api.Application.StudentsManagement.Registration;
using Api.Domain.Common.Utilities;
using Api.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

public class StudentsController : ApiController
{
    private readonly ISender _sender;

    public StudentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> RegisterStudent(RegisterStudentCommand command)
    {
        var response = await _sender.Send(command);
        if (response.IsFailed)
            return BadRequest(response.Errors.First());
        return Ok(response.Value);
    }
}
