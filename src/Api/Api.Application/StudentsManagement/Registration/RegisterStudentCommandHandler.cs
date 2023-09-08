using Api.Application.Authentication.Errors;
using Api.Application.Common;
using Api.Application.Repositories;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Application.StudentsManagement.Registration;

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, Result<StudentResponse>>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterStudentCommandHandler(
        IAdminRepository adminRepository,
        IUnitOfWork unitOfWork)
    {
        _adminRepository = adminRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StudentResponse>> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        AdminId? adminId = AdminId.Create(request.AdminId);
        if (adminId is null)
            return Result.Fail(new UserNotFoundError(request.AdminId));

        Admin? admin = await _adminRepository.GetByIdAsync(adminId);
        if (admin is null)
            return Result.Fail(new UserNotFoundError(request.AdminId));

        Password password = Password.CreateNewPassword(request.Password);
        Student student = admin.RegisterStudent(
            request.FirstName,
            request.LastName,
            request.DateOfBirth,
            request.Level,
            password,
            request.Year,
            request.Specialization);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new StudentResponse(
            student.Id.Value,
            student.FirstName,
            student.LastName,
            student.Password.Hash,
            student.Role,
            student.Classes
                .Select(c => c.Id.Value)
                .ToArray());
    }
}
