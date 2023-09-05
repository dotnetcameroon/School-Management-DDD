using Api.Domain.Common.Models;

namespace Api.Domain.AcademicAggregate.ValueObjects;

public class SemesterId : ValueObject
{
    private readonly int _year;
    private readonly int _semesterNumber;
    public string Value { get; set; }

    private SemesterId(
        int year,
        int semesterNumber)
    {
        _year = year;
        _semesterNumber = semesterNumber;
        Value = $"{year}_{semesterNumber}";
    }

#pragma warning disable CS8618
    private SemesterId()
    {
    }
#pragma warning restore CS8618

    public static SemesterId Create(
        int year,
        int semesterNumber)
    {
        return new(year, semesterNumber);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return _year;
        yield return _semesterNumber;
    }
}
