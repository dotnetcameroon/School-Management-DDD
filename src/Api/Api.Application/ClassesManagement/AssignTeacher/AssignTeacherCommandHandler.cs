namespace Api.Application.ClassesManagement.AssignTeacher;

public class AssignTeacherCommandHandler : IRequestHandler<AssignTeacherCommand, Result<SchoolClassResponse>>
{
    public Task<Result<SchoolClassResponse>> Handle(AssignTeacherCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
