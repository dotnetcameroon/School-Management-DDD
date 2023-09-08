using Api.Domain.AcademicAggregate.Enums;

namespace Api.Application.StudentsManagement.Registration;

public record RegisterStudentCommand(
    string AdminId,
    string? FirstName,
    string LastName,
    string Password,
    DateTime DateOfBirth,
    int Level,
    int Year,
    Specialization Specialization) : IRequest<Result<StudentResponse>>;
