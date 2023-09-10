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

    public async Task<TEntity?> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        //await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<TEntity>()
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<TEntity>()
            .Where(entity => id.Equals(entity.Id))
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        var values = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(predicate)
            .ToArrayAsync(cancellationToken);

        return values;
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

        return entities;
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        var entity = await _context
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => id.Equals(entity.Id), cancellationToken = default);

        return entity;
    }
}
