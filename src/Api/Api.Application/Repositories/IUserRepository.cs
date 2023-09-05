using Api.Application.Repositories.Base;
using Api.Domain.SchoolAggregate;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Application.Repositories;

public interface IUserRepository : IRepository<User, UserId>
{
}
