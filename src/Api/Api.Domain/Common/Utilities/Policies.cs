namespace Api.Domain.Common.Utilities;

public class Policies
{
    public const string AdminOnly = nameof(AdminOnly);
    public const string TeacherOnly = nameof(TeacherOnly);
    public const string AdminAndTeachersOnly = nameof(AdminAndTeachersOnly);
    public const string TeachersAndStudentsOnly = nameof(TeachersAndStudentsOnly);
}
