namespace Api.Domain.SchoolClassAggregate.Entities;

// Manages the students of his class
public class TeacherAdvisor
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<SchoolClass> Classes { get; set; } = Array.Empty<SchoolClass>();
}
