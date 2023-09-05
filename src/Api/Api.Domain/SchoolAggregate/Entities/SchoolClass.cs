using Api.Domain.AcademicAggregate.Entities;
using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.Common.Models;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.SchoolAggregate.Entities;

public class SchoolClass : Entity<SchoolClassId>
{
    private readonly List<Student> _students = new();

    public int Year { get; }
    public Specialization Specialization { get; }
    public TeacherAdvisor? TeacherAdvisor { get; internal set; }
    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    private SchoolClass(
        SchoolClassId id,
        Specialization specialization,
        TeacherAdvisor? teacherAdvisor,
        int year) : base(id)
    {
        TeacherAdvisor = teacherAdvisor;
        Specialization = specialization;
        Year = year;
    }

    public static SchoolClass CreateUnique(
        Specialization specialization,
        TeacherAdvisor? teacherAdvisor,
        int year)
    {
        return new(
            SchoolClassId.CreateUnique(specialization, year),
            specialization,
            teacherAdvisor,
            year);
    }

    public bool AddStudent(Student student)
    {
        _students.Add(student);
        student.AddClass(Id);
        return true;
    }

    public bool RemoveStudent(Student student)
    {
        _students.Add(student);
        student.RemoveClass(Id);
        return true;
    }

    public static SchoolClass Create(
        SchoolClassId schoolClassId,
        TeacherAdvisor? teacherAdvisor,
        Specialization specialization,
        int year)
    {
        return new(
            schoolClassId,
            specialization,
            teacherAdvisor,
            year);
    }
}
