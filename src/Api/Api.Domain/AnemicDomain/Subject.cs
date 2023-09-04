namespace Api.Domain.AnemicDomain;

public class Subject
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public Semester Semester { get; set; } = null!;
}
