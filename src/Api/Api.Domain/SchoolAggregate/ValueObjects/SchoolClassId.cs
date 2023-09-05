using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.Common.Models;

namespace Api.Domain.SchoolAggregate.ValueObjects;

public class SchoolClassId : ValueObject
{
    private readonly Specialization _specialisation;
    private readonly int _year;
    private readonly int _salt;
    public string Value { get; }

    private SchoolClassId(
        Specialization specialisation,
        int year,
        int salt)
    {
        _year = year;
        _salt = salt;
        _specialisation = specialisation;
        Value = $"Class_{_specialisation}_{_year}_{_salt}";
    }

    public static SchoolClassId CreateUnique(
        Specialization specialisation,
        int year)
    {
        return new(
            specialisation,
            year,
            Random.Shared.Next(10000, 99999));
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return _specialisation;
        yield return _year;
        yield return _salt;
    }
}
