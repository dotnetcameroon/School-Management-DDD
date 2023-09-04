namespace Api.Domain.AnemicDomain;

public class Specialisation
{
    public int Name { get; set; }
    public SpecialisationType Type { get; set; }
}

public enum SpecialisationType
{
    SoftwareEngineering,
    DataScience,
    ArtificialIntelligence,
    BigData
}
