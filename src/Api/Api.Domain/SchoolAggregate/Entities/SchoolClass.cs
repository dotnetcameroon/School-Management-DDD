using Api.Domain.AcademicAggregate.Enums;
using Api.Domain.Common.Models;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.SchoolAggregate.Entities;

public class SchoolClass : Entity<SchoolClassId>
{
    private readonly List<Student> _students = new();

    public int Year { get; }
    public Specialization Specialization { get; }
    public TeacherAdvisor? TeacherAdvisor { get; private set; }
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

    private SchoolClass(
        SchoolClassId id,
        Specialization specialization,
        TeacherAdvisor? teacherAdvisor,
        IEnumerable<Student> students,
        int year) : base(id)
    {
        _students = students.ToList();
        TeacherAdvisor = teacherAdvisor;
        Specialization = specialization;
        Year = year;
    }

    private SchoolClass()
    {
    }

    internal static SchoolClass CreateUnique(
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

    internal static SchoolClass Create(
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

    internal static SchoolClass Create(
        SchoolClassId schoolClassId,
        TeacherAdvisor? teacherAdvisor,
        Specialization specialization,
        IEnumerable<Student> students,
        int year)
    {
        return new(
            schoolClassId,
            specialization,
            teacherAdvisor,
            students,
            year);
    }

    internal void ChangeTeacher(TeacherAdvisor? teacher)
    {
        TeacherAdvisor = teacher;
    }

    internal bool AddStudent(Student student)
    {
        _students.Add(student);
        student.AddClass(this);
        return true;
    }

    internal bool RemoveStudent(Student student)
    {
        _students.Add(student);
        student.RemoveClass(this);
        return true;
    }
}
