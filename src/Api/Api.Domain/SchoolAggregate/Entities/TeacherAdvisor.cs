using Api.Domain.AcademicAggregate.Entities;
using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.Common.Models;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.SchoolAggregate.Entities;

// Manages the students of his class
public class TeacherAdvisor : Entity<TeacherAdvisorId>
{
    private readonly List<SchoolClass> _classes = new();
    public string? FirstName { get; }
    public string LastName { get; }
    public IReadOnlyList<SchoolClass> Classes => _classes.AsReadOnly();

    private TeacherAdvisor(
        TeacherAdvisorId id,
        string? firstName,
        string lastName) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public bool AssignClass(SchoolClass @class)
    {
        // Validation checks
        _classes.Add(@class);
        @class.TeacherAdvisor = this;
        return true;
    }

    public bool UnAssignClass(SchoolClass @class)
    {
        // Verification checks
        _classes.Remove(@class);
        @class.TeacherAdvisor = null;
        return true;
    }

    public bool NoteStudent(
        Discipline discipline,
        StudentId studentId,
        int year,
        decimal note)
    {
        var @class = _classes
            .FirstOrDefault(c => c.Year == year && c.Students.Any(s => s.Id == studentId));

        var student = @class?.Students.FirstOrDefault(s => s.Id == studentId);
        if(student is null)
            return false;

        student.AddNotation(
            Notation.CreateUnique(student, note, discipline));

        return true;
    }

    public static TeacherAdvisor CreateUnique(
        string? firstName,
        string lastName,
        int year)
    {
        return new(
            TeacherAdvisorId.CreateUnique(year),
            firstName,
            lastName);
    }

    public static TeacherAdvisor Create(
        TeacherAdvisorId id,
        string? firstName,
        string lastName)
    {
        return new(
            id,
            firstName,
            lastName);
    }
}
