namespace Api.Application.TeachersManagement.Registration;

public record RegisterTeacherCommand(
    string AdminId,
    string? FirstName,
    string LastName,
    string Password) : IRequest<Result<TeacherResponse>>;
