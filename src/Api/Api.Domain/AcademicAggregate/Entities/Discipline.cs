﻿using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.Common.Models;

namespace Api.Domain.AcademicAggregate.Entities;

public class Discipline : Entity<DisciplineId>
{
    public string Title { get; set; }
    public Semester Semester { get; }

    private Discipline(
        DisciplineId id,
        string title,
        Semester semester) : base(id)
    {
        Title = title;
        Semester = semester;
    }

#pragma warning disable CS8618
    private Discipline()
    {
    }
#pragma warning restore CS8618

    public static Discipline CreateUnique(
        string title,
        Semester semester,
        int year)
    {
        return new(
            DisciplineId.CreateUnique(year),
            title,
            semester);
    }
}
