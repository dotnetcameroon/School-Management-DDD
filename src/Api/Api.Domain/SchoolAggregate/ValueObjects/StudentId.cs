using Api.Domain.Common.Utilities;

namespace Api.Domain.SchoolAggregate.ValueObjects;

public class StudentId : UserId
{
    public const string _prefix = "Std";
    protected override string Prefix => _prefix;

    public StudentId(string code, int year, int salt) : base(code, year, salt)
    {
    }

    private StudentId()
    {
    }

    public static StudentId CreateUnique(
        int year)
    {
        return new(
            RandomCodeGenerator.GetRandomCode(3),
            year,
            Random.Shared.Next(10000, 99999));
    }

    public static new StudentId? Create(string value)
    {
        var (year, code, salt) = Decrypt(value, _prefix);
        if (year == 0 || salt == 0)
            return null;

        return new(code, year, salt);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return _prefix;
        yield return _year;
        yield return _code;
        yield return _salt;
    }
}
