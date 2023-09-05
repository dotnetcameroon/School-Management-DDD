using Api.Domain.Common.Models;

namespace Api.Application.Repositories.Base;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    Task<TEntity?> GetByIdAsync(TId id);
    Task<IReadOnlyList<TEntity>> GetAsync(Func<bool, TEntity> predicate);
    Task<TEntity?> AddAsync(TEntity entity);
    Task<int> DeleteByIdAsync(TId id);
    Task<int> DeleteAsync(Func<bool, TEntity> predicate);
}
