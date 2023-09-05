namespace Api.Application.Authentication.Errors;

public class UserNotFoundError : IError
{
    private readonly object _id;

    public UserNotFoundError(object id)
    {
        _id = id;
    }

    public List<IError> Reasons => new();

    public string Message => $"The user with Id {_id} does not exist";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
