using System.Linq.Expressions;
using Api.Domain.Common.Models;

namespace Api.Application.Repositories.Base;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> GetAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
