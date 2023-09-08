using Api.Domain.AcademicAggregate.Enums;
using Api.Domain.Common.Utilities;
using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Domain.SchoolAggregate.Entities;

public class Admin : User
{
    // The admin should be able to create and desolve classes, so he should have the list of all existing classes
    // Actually, from the user base class he already have all students

    private readonly List<Student> _studens = new();
    public IReadOnlyList<Student> Students => _studens.AsReadOnly();

    public Admin(
        AdminId id,
        string? firstName,
        string lastName,
        Password password,
        string role) : base(id, firstName, lastName, password, role)
    {
    }

    private Admin()
    {
    }

    #region Admin Creation Concerns
    public static Admin CreateUnique(
        string? firstName,
        string lastName,
        Password password,
        int nominationYear)
    {
        return new(
            AdminId.CreateUnique(nominationYear),
            firstName,
            lastName,
            password,
            Roles.Admin);
    }

    public static Admin Create(
        AdminId id,
        string? firstName,
        string lastName,
        Password password)
    {
        return new(
            id,
            firstName,
            lastName,
            password,
            Roles.Admin);
    }
    #endregion

    #region Classes Administration concerns
    public SchoolClass CreateUniqueClass(
        Specialization specialization,
        TeacherAdvisor? teacherAdvisor,
        int year)
    {
        var @class = SchoolClass.CreateUnique(
            specialization,
            teacherAdvisor,
            year);

        _classes.Add(@class);
        return @class;
    }

    public SchoolClass CreateClass(
        SchoolClassId schoolClassId,
        TeacherAdvisor? teacherAdvisor,
        Specialization specialization,
        int year)
    {
        var @class = SchoolClass.Create(
            schoolClassId,
            teacherAdvisor,
            specialization,
            year);

        _classes.Add(@class);
        return @class;
    }

    public SchoolClass CreateClass(
        SchoolClassId schoolClassId,
        TeacherAdvisor? teacherAdvisor,
        Specialization specialization,
        IEnumerable<Student> students,
        int year)
    {
        var @class = SchoolClass.Create(
            schoolClassId,
            teacherAdvisor,
            specialization,
            students,
            year);

        _classes.Add(@class);
        return @class;
    }

    public bool DisolveClass(SchoolClassId schoolClassId)
    {
        var @class = _classes.FirstOrDefault(c => c.Id == schoolClassId);
        if (@class is null)
            return false;

        @class.ChangeTeacher(null);
        while (@class.Students.Any())
        {
            /* We remove the last element from the list each time because of the behaviour of lists
             * when we try to remove an element inside a list, the whole remaining elemenrs got moved
             * to the index - 1
             */
            var student = @class.Students[@class.Students.Count - 1];
            student.RemoveClass(@class);
            @class.RemoveStudent(student);
        }

        return true;
    }
    #endregion

    #region Student Adminitration concerns

    public Student RegisterStudent(
        string? firstName,
        string lastName,
        DateTime dateOfBirth,
        int level,
        Password password,
        int year,
        Specialization? specialization)
    {
        var student = Student.CreateUnique(
            firstName,
            lastName,
            dateOfBirth,
            level,
            password,
            year,
            specialization);

        _studens.Add(student);
        return student;
    }

    public bool DismissStudent(StudentId studentId)
    {
        var student = _studens.FirstOrDefault(s => s.Id == studentId);
        if (student is null)
            return false;

        var @class = _classes.Where(c => c.Students.Contains(student)).OrderBy(c => c.Year).Last();
        if (@class is null)
            return false;

        @class.RemoveStudent(student);
        while(student.Classes.Any())
            student.RemoveClass(student.Classes[student.Classes.Count - 1]);

        return true;
    }
    #endregion
}
