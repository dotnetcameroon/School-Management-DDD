using Api.Domain.AcademicAggregate.Enums;
using Api.Domain.Common.Models;

namespace Api.Domain.SchoolAggregate.ValueObjects;

public class SchoolClassId : ValueObject
{
    private readonly Specialization _specialization;
    private readonly int _year;
    private readonly int _salt;
    public string Value { get; }

    private SchoolClassId(
        Specialization specialization,
        int year,
        int salt)
    {
        _year = year;
        _salt = salt;
        _specialization = specialization;
        Value = $"Class_{_specialization}_{_year}_{_salt}";
    }

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
}
