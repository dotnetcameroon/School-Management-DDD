using Api.Domain.AcademicAggregate.Entities;
using Api.Domain.Common.Utilities;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.SchoolAggregate.Entities;

// Manages the students of his class
public class TeacherAdvisor : User
{
    private TeacherAdvisor(
        TeacherAdvisorId id,
        string? firstName,
        string lastName,
        Password password,
        string role) : base(id, firstName, lastName, password, role)
    {
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
        Password password,
        int year,
        string role)
    {
        return new(
            TeacherAdvisorId.CreateUnique(year),
            firstName,
            lastName,
            password,
            Roles.Teacher);
    }

    public static TeacherAdvisor Create(
        TeacherAdvisorId id,
        string? firstName,
        string lastName,
        Password password,
        string role)
    {
        return new(
            id,
            firstName,
            lastName,
            password,
            Roles.Teacher);
    }
}
