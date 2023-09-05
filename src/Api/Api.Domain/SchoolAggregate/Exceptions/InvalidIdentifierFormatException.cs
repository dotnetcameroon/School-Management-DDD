namespace Api.Domain.SchoolAggregate.Exceptions;

public class InvalidIdentifierFormatException : Exception
{
    public override string Message => "The provided identifier does not match the conventional format";
}
