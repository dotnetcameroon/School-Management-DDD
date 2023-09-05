using Api.Application.Repositories;
using Api.Domain.SchoolAggregate;
using Api.Domain.SchoolAggregate.ValueObjects;
using Api.Infrastructure.Persistance.Base;

namespace Api.Infrastructure.Persistance.Repositories;

public class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
