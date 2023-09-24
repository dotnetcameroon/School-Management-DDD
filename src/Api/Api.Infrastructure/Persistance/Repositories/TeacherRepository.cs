using Api.Application.Repositories;
using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;
using Api.Infrastructure.Persistance.Base;

namespace Api.Infrastructure.Persistance.Repositories;

public class TeacherRepository : Repository<TeacherAdvisor, UserId>, ITeacherRepository
{
    public TeacherRepository(AppDbContext context) : base(context)
    {
    }
}
