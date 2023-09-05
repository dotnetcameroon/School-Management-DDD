using Api.Domain.Common.Models;
using Api.Domain.Common.Utilities;

namespace Api.Domain.AcademicAggregate.ValueObjects;

public class StudentId : ValueObject
{
    private const string _prefix = "Std";
    private readonly int _year;
    private readonly string _code;
    private readonly int _salt;
    public string Value { get; }

    private StudentId(
        string code,
        int year,
        int salt)
    {
        _code = code;
        _year = year;
        _salt = salt;
        Value = $"{_prefix}_{_code}_{_year}_{_salt}";
    }

    public static StudentId CreateUnique(
        int year)
    {
        return new(
            RandomCodeGenerator.GetRandomCode(3),
            year,
            Random.Shared.Next(10000, 99999));
    }

    public static StudentId? Create(string value)
    {
        string[] components = value.Split('_');
        if (components.Length != 4)
            return null;

        if (!components[0].Equals(_prefix))
            return null;

        string code = components[1];
        _ = int.TryParse(components[2], out int year);
        _ = int.TryParse(components[3], out int salt);

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
