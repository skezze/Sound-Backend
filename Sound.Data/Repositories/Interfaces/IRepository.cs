using System.Linq.Expressions;
using Sound.Core.Interfaces.Entities;

public interface IRepository<T> where T : class, IEntity
{
    Task<T?> GetByIdAsync(object id);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetQueryable();
    bool Any(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    Task<int> SaveChangesAsync();
}