namespace Api.Domain.AnemicDomain;

public class SchoolClass
{
    public int Id { get; set; }
    public int Year { get; set; }
    public TeacherAdvisor TeacherAdvisor { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = Array.Empty<Student>();
}
