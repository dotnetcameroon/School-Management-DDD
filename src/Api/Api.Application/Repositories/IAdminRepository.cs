using Api.Application.Repositories.Base;
using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;

namespace Api.Application.Repositories;

public interface IAdminRepository : IRepository<Admin, UserId>
{
}
