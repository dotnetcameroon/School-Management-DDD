using Api.Application.Repositories;
using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;
using Api.Infrastructure.Persistance.Base;

namespace Api.Infrastructure.Persistance.Repositories;

public class AdminRepository : Repository<Admin, UserId>, IAdminRepository
{
    public AdminRepository(AppDbContext context) : base(context)
    {
    }
}
