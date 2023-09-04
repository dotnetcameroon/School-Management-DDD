namespace Api.Domain.AnemicDomain;

public class Notation
{
    public decimal Value { get; set; }
    public Subject Subject { get; set; } = null!;
    public Grade Grade { get; set; }
}
