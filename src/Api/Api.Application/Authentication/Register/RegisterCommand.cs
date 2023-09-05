namespace Api.Application.Authentication.Register;
public record RegisterCommand(
    string? FirstName,
    string LastName,
    string Password,
    string Role,
    DateTime DateOfBirth,
    int Level) : IRequest<Result<RegisterResponse>>;
