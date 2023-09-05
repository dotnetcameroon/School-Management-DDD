using System.Security.Claims;
using Api.Application.Authentication.Services;
using Api.Application.Repositories;
using Api.Domain.Common.Utilities;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate;
using Api.Domain.SchoolAggregate.Entities;

namespace Api.Application.Authentication.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwt;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwt)
    {
        _userRepository = userRepository;
        _jwt = jwt;
    }

    public async Task<Result<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Password password = Password.CreateNewPassword(request.Password);

        // Create the user Entity
        User user = request.Role switch
        {
            Roles.Teacher => TeacherAdvisor.CreateUnique(
                request.FirstName,
                request.LastName,
                password,
                request.Year,
                Roles.Teacher),

            _ => Student.CreateUnique(
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.Level,
                password,
                request.Year,
                request.Specialization)
        };

        // Save it to the database
        await _userRepository.AddAsync(user);

        // Generate the token
        string token = _jwt.GenerateToken(new[]
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.NameIdentifier, user.Id.Value),
        });

        return new RegisterResponse(user.Id.Value, token);
    }
}
