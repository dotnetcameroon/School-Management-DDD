using Api.Application.Repositories.Base;
using Api.Domain.Common.Models;

namespace Api.Infrastructure.Persistance.Base;

public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    private readonly AppDbContext _context;

    protected Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public Task<int> DeleteAsync(Func<bool, TEntity> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteByIdAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<TEntity>> GetAsync(Func<bool, TEntity> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetByIdAsync(TId id)
    {
        throw new NotImplementedException();
    }
}
