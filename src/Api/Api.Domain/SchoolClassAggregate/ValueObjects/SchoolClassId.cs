using Api.Domain.Common.Models;

namespace Api.Domain.SchoolClassAggregate.ValueObjects;

public class SchoolClassId : ValueObject
{
    private readonly Specialisation _specialisation;
    private readonly int _year;
    private readonly int _salt;
    public string Value { get; }

    private SchoolClassId(
        Specialisation specialisation,
        int year,
        int salt)
    {
        _year = year;
        _salt = salt;
        _specialisation = specialisation;
        Value = $"Class_{_specialisation}_{_year}_{_salt}";
    }

    public static SchoolClassId CreateUnique(
        Specialisation specialisation,
        int year)
    {
        return new(
            specialisation,
            year,
            Random.Shared.Next(10000, 99999));
    }

    public static SchoolClassId Create(
        Specialisation specialisation,
        int year,
        int salt)
    {
        return new(
            specialisation,
            year,
            salt);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return _specialisation;
        yield return _year;
        yield return _salt;
    }
}
