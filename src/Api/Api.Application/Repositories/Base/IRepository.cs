using System.Linq.Expressions;
using Api.Domain.Common.Models;

namespace Api.Application.Repositories.Base;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    Task<TEntity?> GetByIdAsync(TId id);
    Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IReadOnlyList<TEntity>> GetAsync();
    Task<TEntity?> AddAsync(TEntity entity);
    Task<int> DeleteByIdAsync(TId id);
    Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
}
