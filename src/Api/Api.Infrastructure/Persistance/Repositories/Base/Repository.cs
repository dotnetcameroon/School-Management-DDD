using System.Linq.Expressions;
using Api.Application.Repositories.Base;
using Api.Domain.Common.Models;

namespace Api.Infrastructure.Persistance.Base;

public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    protected readonly AppDbContext _context;

    protected Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context
            .Set<TEntity>()
            .Where(predicate)
            .ExecuteDeleteAsync();
    }

    public async Task<int> DeleteByIdAsync(TId id)
    {
        return await _context
            .Set<TEntity>()
            .Where(entity => id.Equals(entity.Id))
            .ExecuteDeleteAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var values = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(predicate)
            .ToArrayAsync();

        return values;
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync()
    {
        var entities = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .ToArrayAsync();

        return entities;
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        var entity = await _context
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => id.Equals(entity.Id));

        return entity;
    }
}
