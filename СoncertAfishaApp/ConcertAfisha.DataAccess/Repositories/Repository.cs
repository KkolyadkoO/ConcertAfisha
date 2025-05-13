using ConcertAfisha.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ConcertAfishaAppDBContext _dbContext;
    public Repository(ConcertAfishaAppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
    }
    public async Task<Guid> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return (Guid)typeof(T).GetProperty("Id").GetValue(entity);
    }
    public async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        _dbContext.Set<T>().Remove(entity);
    }
}