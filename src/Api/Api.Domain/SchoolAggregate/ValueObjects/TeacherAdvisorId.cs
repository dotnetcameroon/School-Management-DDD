using Api.Domain.Common.Utilities;

namespace Api.Domain.SchoolAggregate.ValueObjects;

public class TeacherAdvisorId : UserId
{
    public const string _prefix = "Teacher";
    protected override string Prefix => _prefix;

    public TeacherAdvisorId(string code, int year, int salt) : base(code, year, salt)
    {
    }

    private TeacherAdvisorId()
    {
    }

    public static TeacherAdvisorId CreateUnique(
        int year)
    {
        return new(
            RandomCodeGenerator.GetRandomCode(3),
            year,
            Random.Shared.Next(10000, 99999));
    }

    // The overload used to convert back values received from the database to the actual strongly typed Id
    public static new TeacherAdvisorId? Create(string value)
    {
        var (year, code, salt) = Decrypt(value, _prefix);
        if (year == 0 || salt == 0)
            return null;

        return new(code, year, salt);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return _code;
        yield return _year;
        yield return _salt;
    }
}
