namespace Api.Application.TeachersManagement;

public record TeacherResponse(
    string Id,
    string? FirstName,
    string LastName,
    string Password);
