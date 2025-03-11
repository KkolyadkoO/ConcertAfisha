using ConcertAfisha.Core.Abstractions;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess.Repositories;

public class ConcertRepository(ConcertAfishaAppDBContext dbContext) : Repository<Concert>(dbContext), IConcertRepository
{
    public override async Task<List<Concert>> GetAllAsync()
    {
        var concertEntities = await _dbContext.ConcertEntities
            .AsNoTracking()
            .Include(e => e.Members)
            .OrderBy(e => e.Date)
            .ToListAsync();
        return concertEntities;
    }

    public override async Task<Concert> GetByIdAsync(Guid id)
    {
        var concert = await _dbContext.ConcertEntities
            .AsNoTracking()
            .Include(e => e.Members)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        return concert;
    }
    
    public async Task<(List<Concert>, int)> GetBySpecificationAsync(ISpecification<Concert> spec, int? page, int? size)
    {
        var query = ApplySpecification(spec, _dbContext.ConcertEntities);
        
        var countOfConcert = await query.CountAsync();
        
        if (page.HasValue && size.HasValue)
        {
            query = query.Skip((int)((page - 1) * size)).Take((int)size);
        }
        
        var events = await query
            .Include(e => e.Members)
            .AsNoTracking()
            .ToListAsync();

        return (events, countOfConcert);
    }
    
    private IQueryable<Concert> ApplySpecification(ISpecification<Concert> spec, IQueryable<Concert> query)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        if (spec.OrderBy != null)
        {
            query = spec.OrderBy(query);
        }

        return query;
    }
}