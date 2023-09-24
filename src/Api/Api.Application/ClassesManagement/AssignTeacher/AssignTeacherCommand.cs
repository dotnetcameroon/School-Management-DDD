namespace Api.Application.ClassesManagement.AssignTeacher;

public record AssignTeacherCommand() : IRequest<Result<SchoolClassResponse>>;
