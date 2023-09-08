namespace docs.Items;

internal class SchoolClass
{
    public int Year { get; set; }
    public Specialization Specialization { get; set; }
    public TeacherAdvisor TeacherAdvisor { get; set; }
    public List<Student> Students { get; set; }
}
