using System.Security.Claims;
using Api.Application.Authentication.Errors;
using Api.Application.Authentication.Services;
using Api.Application.Repositories;
using Api.Application.Repositories.Base;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Application.Authentication.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwt;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwt)
    {
        _userRepository = userRepository;
        _jwt = jwt;
    }

    public async Task<Result<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // Get the user from the database
        UserId? identifier = UserId.Create(request.Identifier);

        if (identifier is null)
            return Result.Fail(new UserNotFoundError(request.Identifier));
        User? user = await _userRepository.GetByIdAsync(identifier);

        if(user is null)
            return Result.Fail(new UserNotFoundError(request.Identifier));

        if(user.Password != Password.CreateNewPassword(request.Password))
            return Result.Fail(new BadCredentialsError());

        // Generate the token
        string token = _jwt.GenerateToken(new[]
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.NameIdentifier, user.Id.Value),
        });

        // Return back the token to the user
        return new LoginResponse(token);
    }
}
