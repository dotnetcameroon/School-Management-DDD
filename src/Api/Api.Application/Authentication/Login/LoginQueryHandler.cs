namespace Api.Application.Authentication.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginResponse>>
{
    public Task<Result<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
