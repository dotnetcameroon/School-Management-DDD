namespace Api.Application.StudentsManagement;

public record StudentResponse(
    string Identifier,
    string? FirstName,
    string LastName,
    string Password,
    string Role,
    IReadOnlyList<string> Classes);
