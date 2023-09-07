namespace Api.Application.UsersManagement;

public record UserResponse(
    string Identifier,
    string? FirstName,
    string LastName,
    string Password,
    string Role,
    IReadOnlyList<string> Classes
    );
