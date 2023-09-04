namespace Api.Domain.AnemicDomain;

public class Notation
{
    public decimal Value { get; set; }
    public Subject Subject { get; set; } = null!;
    public Grade Grade { get; set; }
}

public enum Grade
{
    A_Plus,
    A,
    A_Minus,
    B_Plus,
    B,
    B_Minus,
    C_Plus,
    C,
    C_Minus
}
