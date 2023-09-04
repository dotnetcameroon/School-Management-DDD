namespace Api.Domain.AnemicDomain;

public class Student
{
    public int Id { get; set; }
    public string Password { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public int Level { get; set; }
    public Specialisation? Specialisation { get; set; }
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public ICollection<Notation> Notations { get; set; } = null!;
}
