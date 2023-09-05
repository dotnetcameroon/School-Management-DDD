using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.Common.Models;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.AcademicAggregate.Entities;

public class Student : Entity<StudentId>
{
    private readonly List<SchoolClassId> _classes = new();
    private readonly List<Notation> _notations = new();

    public string? FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    public int Level { get; private set; }
    public string Password { get; private set; }
    public Specialization? Specialization { get; private set; }

    public IReadOnlyList<SchoolClassId> Classes => _classes.AsReadOnly();
    public IReadOnlyList<Notation> Notations => _notations.AsReadOnly();

    private Student(
        StudentId id,
        string? firstName,
        string lastName,
        DateTime dateOfBirth,
        int level,
        string password,
        Specialization? specialization) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Level = level;
        Password = password;
        Specialization = specialization;
    }

    internal void AddClass(SchoolClassId @class)
    {
        _classes.Add(@class);
    }

    internal void RemoveClass(SchoolClassId @class)
    {
        _classes.Remove(@class);
    }

    internal bool AddNotation(Notation notation)
    {
        _notations.Add(notation);
        return true;
    }

    internal void UpdateNotation(NotationId notationId, decimal? value)
    {
        var notation = _notations.FirstOrDefault(n => n.Id == notationId);
        if(notation is null)
            return;

        notation.UpdateValue(value);
    }

    public static Student CreateUnique(
        string? firstName,
        string lastName,
        DateTime dateOfBirth,
        int level,
        string password,
        int year,
        Specialization? specialization)
    {
        return new(
            StudentId.CreateUnique(year),
            firstName,
            lastName,
            dateOfBirth,
            level,
            password,
            specialization);
    }

    public static Student Create(
        StudentId id,
        string? firstName,
        string lastName,
        DateTime dateOfBirth,
        int level,
        string password,
        int year,
        Specialization? specialization)
    {
        return new(
            id,
            firstName,
            lastName,
            dateOfBirth,
            level,
            password,
            specialization);
    }
}
