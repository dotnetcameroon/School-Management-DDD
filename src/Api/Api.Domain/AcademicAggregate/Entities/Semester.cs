using Api.Domain.Common.Models;

namespace Api.Domain.AcademicAggregate.Entities;

public class Semester : Entity<Guid>
{
    public int SemesterNumber { get; set; }
    public int Year { get; set; }

    public Semester(Guid id) : base(id)
    {
    }

    private Semester()
    {
    }
}
