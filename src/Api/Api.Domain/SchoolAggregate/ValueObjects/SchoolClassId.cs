using System.Text;
using Api.Domain.AcademicAggregate.Enums;
using Api.Domain.Common.Models;

namespace Api.Domain.SchoolAggregate.ValueObjects;

public class SchoolClassId : ValueObject
{
    private readonly Specialization _specialization;
    private readonly int _year;
    private readonly int _salt;
    private const char _separator = '_';
    private const string _prefix = "Class";

    public string Value { get; }

    private SchoolClassId(
        Specialization specialization,
        int year,
        int salt)
    {
        _year = year;
        _salt = salt;
        _specialization = specialization;
        Value = new StringBuilder().AppendJoin(
            separator: _separator,
            _prefix,
            _specialization,
            _year,
            _salt).ToString();
    }

#pragma warning disable CS8618
    private SchoolClassId()
    {
    }
#pragma warning restore CS8618

    public static SchoolClassId CreateUnique(
        Specialization specialization,
        int year)
    {
        return new(
            specialization,
            year,
            Random.Shared.Next(10000, 99999));
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return _specialization;
        yield return _year;
        yield return _salt;
    }

    public static SchoolClassId Create(string value)
    {
        var (year, specialization, salt) = Decrypt(value, _prefix);
        return new(specialization, year, salt);
    }

    private static (int year, Specialization Specialization, int salt) Decrypt(string value, string prefix)
    {
        string[] components = value.Split(_separator);
        if (components.Length != 4)
            throw new Exception();

        if (!components[0].Equals(prefix))
            throw new Exception();

        _ = int.TryParse(components[1], out int specialization);
        _ = int.TryParse(components[2], out int year);
        _ = int.TryParse(components[3], out int salt);

        return (year, (Specialization)specialization, salt);
    }
}
