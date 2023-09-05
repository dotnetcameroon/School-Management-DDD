using Api.Domain.Common.Models;
namespace Api.Domain.AcademicAggregate.ValueObjects;

public class Specialization : ValueObject
{
    public int Name { get; }
    public SpecializationType Type { get; }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return Name;
        yield return Type;
    }
}

public enum SpecializationType
{
    SoftwareEngineering,
    DataScience,
    ArtificialIntelligence,
    BigData
}
