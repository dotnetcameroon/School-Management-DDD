namespace Api.Application.Authentication.Errors;

public class BadCredentialsError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The submitted credentials are not valid";

    public Dictionary<string, object> Metadata => new();
}
