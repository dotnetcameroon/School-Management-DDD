namespace docs.Items;

internal class Student : User
{
    public DateTime DateOfBirth { get; set; }
    public int Level { get; set; }
    public Specialization Specialization { get; set; }
    public ICollection<Notation> Notations { get; set; }
}
