namespace Api.Domain.SchoolAggregate.Exceptions;

public class WrongPrefixException : Exception
{
    public override string Message => "The prefix of the identifier does not match the actual prefix of the assumed entity";
}

