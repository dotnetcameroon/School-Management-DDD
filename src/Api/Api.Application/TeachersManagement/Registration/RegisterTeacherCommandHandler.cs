using Api.Application.Authentication.Errors;
using Api.Application.Common;
using Api.Application.Repositories;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Application.TeachersManagement.Registration;

public class RegisterTeacherCommandHandler : IRequestHandler<RegisterTeacherCommand, Result<TeacherResponse>>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterTeacherCommandHandler(IUnitOfWork unitOfWork, IAdminRepository adminRepository)
    {
        _unitOfWork = unitOfWork;
        _adminRepository = adminRepository;
    }

    public async Task<Result<TeacherResponse>> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
    {
        var password = Password.CreateNewPassword(request.Password);
        var admin = await _adminRepository.GetByIdAsync(
            AdminId.Create(request.AdminId)!,
            cancellationToken: cancellationToken);

        if (password is null)
            return Result.Fail(new BadCredentialsError());

        TeacherAdvisor? teacher = admin!.RegisterTeacher(
            request.FirstName,
            request.LastName,
            password,
            DateTime.Now.Year);

        if (teacher is null)
            return Result.Fail(new BadCredentialsError());

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new TeacherResponse(
            teacher.Id.Value,
            teacher.FirstName,
            teacher.LastName,
            teacher.Password.Hash);
    }
}
