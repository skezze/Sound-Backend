using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Sound.Core.Interfaces.Entities;
using Sound.Data.DbContexts;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly SoundDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(SoundDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public bool Any(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Any(predicate);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}