using Api.Domain.AcademicAggregate.Enums;

namespace Api.Application.Authentication.Register;
public record RegisterCommand(
    string? FirstName,
    string LastName,
    string Password,
    string Role,
    DateTime DateOfBirth,
    int Level,
    int Year,
    Specialization? Specialization) : IRequest<Result<RegisterResponse>>;
