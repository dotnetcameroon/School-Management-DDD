using Api.Domain.AcademicAggregate.Entities;
using Api.Domain.AcademicAggregate.Enums;
using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.Common.Utilities;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.SchoolAggregate.Entities;

public class Student : User
{
    private readonly List<Notation> _notations = new();
    public DateTime DateOfBirth { get; }
    public int Level { get; private set; }
    public Specialization? Specialization { get; private set; }
    public IReadOnlyList<Notation> Notations => _notations.AsReadOnly();

    private Student(
        StudentId id,
        string? firstName,
        string lastName,
        Password password,
        DateTime dateOfBirth,
        int level,
        Specialization? specialization,
        string role) : base(id, firstName, lastName, password, role)
    {
        DateOfBirth = dateOfBirth;
        Level = level;
        Specialization = specialization;
    }

    internal void AddClass(SchoolClass @class)
    {
        _classes.Add(@class);
    }

    internal void RemoveClass(SchoolClass @class)
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
        Password password,
        int year,
        Specialization? specialization)
    {
        return new(
            StudentId.CreateUnique(year),
            firstName,
            lastName,
            password,
            dateOfBirth,
            level,
            specialization,
            Roles.Student);
    }

    public static Student Create(
        StudentId id,
        string? firstName,
        string lastName,
        DateTime dateOfBirth,
        int level,
        Password password,
        Specialization? specialization)
    {
        return new(
            id,
            firstName,
            lastName,
            password,
            dateOfBirth,
            level,
            specialization,
            Roles.Student);
    }
}
