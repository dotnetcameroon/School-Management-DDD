using Api.Domain.AcademicAggregate.Enums;
using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.Common.Models;
using Api.Domain.SchoolAggregate.Entities;

namespace Api.Domain.AcademicAggregate.Entities;

public class Notation : Entity<NotationId>
{
    public decimal? Value { get; private set;}
    public Discipline Subject { get; }
    public Grade Grade { get; }
    public Student Student { get; }

    private Notation(
        NotationId id,
        Student student,
        decimal? value,
        Discipline subject,
        Grade grade) : base(id)
    {
        Student = student;
        Value = value;
        Subject = subject;
        Grade = grade;
    }

    public bool UpdateValue(decimal? value)
    {
        // Verification checks
        Value = value;
        return true;
    }

    public static Notation CreateUnique(
        Student student,
        decimal? value,
        Discipline subject)
    {
        // TODO: Get the grade based on the value of the `value` parameter
        Grade grade = Grade.A_Plus;
        return new(
            NotationId.CreateUnique(),
            student,
            value,
            subject,
            grade);
    }

    public static Notation Create(
        NotationId id,
        Student student,
        decimal? value,
        Discipline subject,
        Grade grade)
    {
        return new(
            id,
            student,
            value,
            subject,
            grade);
    }

}
