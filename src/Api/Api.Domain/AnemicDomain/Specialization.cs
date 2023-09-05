namespace Api.Domain.AnemicDomain;

public class Specialization
{
    public int Name { get; set; }
    public SpecializationType Type { get; set; }
}

public enum SpecializationType
{
    SoftwareEngineering,
    DataScience,
    ArtificialIntelligence,
    BigData
}
