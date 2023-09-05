namespace Api.Domain.AnemicDomain;

public class Student
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Level { get; set; }
    public Specialization? Specialization { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ICollection<SchoolClass> Classes { get; set; } = Array.Empty<SchoolClass>();
    public ICollection<Notation> Notations { get; set; } = Array.Empty<Notation>();
}
