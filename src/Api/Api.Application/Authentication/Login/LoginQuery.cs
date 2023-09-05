namespace Api.Application.Authentication.Login;

public record LoginQuery(
    string Identifier,
    string Password) : IRequest<Result<LoginResponse>>;
