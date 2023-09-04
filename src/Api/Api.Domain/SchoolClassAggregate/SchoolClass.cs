using Api.Domain.Common.Models;
using Api.Domain.SchoolClassAggregate.Entities;
using Api.Domain.SchoolClassAggregate.ValueObjects;

namespace Api.Domain.SchoolClassAggregate;

public class SchoolClass : AggregateRoot<SchoolClassId>
{
    public int Year { get; }
    public Specialisation Specialisation { get; private set; }
    public TeacherAdvisor TeacherAdvisor { get; private set; } = null!;
    //public ICollection<Student> Students { get; set; } = Array.Empty<Student>();
    private SchoolClass(
        SchoolClassId id,
        Specialisation specialisation,
        TeacherAdvisor teacherAdvisor,
        int year) : base(id)
    {
        TeacherAdvisor = teacherAdvisor;
        Specialisation = specialisation;
        Year = year;
    }

    public static SchoolClass CreateUnique(
        Specialisation specialisation,
        TeacherAdvisor teacherAdvisor,
        int year)
    {
        return new(
            SchoolClassId.CreateUnique(specialisation, year),
            specialisation,
            teacherAdvisor,
            year);
    }

    public static SchoolClass Create(
        SchoolClassId schoolClassId,
        Specialisation specialisation,
        TeacherAdvisor teacherAdvisor,
        int year)
    {
        return new(
            schoolClassId,
            specialisation,
            teacherAdvisor,
            year);
    }
}
