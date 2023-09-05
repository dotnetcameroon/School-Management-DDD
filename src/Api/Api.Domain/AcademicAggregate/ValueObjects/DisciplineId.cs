using Api.Domain.Common.Models;
using Api.Domain.Common.Utilities;

namespace Api.Domain.AcademicAggregate.ValueObjects;

public class DisciplineId : ValueObject
{
    private readonly string _code;
    private readonly int _salt;
    private readonly int _year;
    public string Value { get; set; }

    private DisciplineId(
        string code,
        int year,
        int salt)
    {
        _code = code;
        _year = year;
        _salt = salt;

        Value = $"{_code}_{_year}_{_salt}";
    }

    public static DisciplineId CreateUnique(
        int year)
    {
        return new(
            RandomCodeGenerator.GetRandomCode(3),
            year,
            Random.Shared.Next(100, 900));
    }

    public static DisciplineId? Create(string value)
    {
        string[] components = value.Split('_');
        if (components.Length != 4)
            return null;

        if (!components[0].Equals("Teacher"))
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
        yield return _code;
        yield return _year;
        yield return _salt;
    }
}
