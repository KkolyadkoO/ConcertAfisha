using ConcertAfisha.Core.Abstractions;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess.Repositories;

public class ConcertRepository(ConcertAfishaAppDBContext dbContext) : IConcertRepository
{
    public async Task<List<Concert>> GetAllAsync()
    {
        var concertEntities = await dbContext.ConcertEntities
            .AsNoTracking()
            .Include(e => e.Members)
            .OrderBy(e => e.Date)
            .ToListAsync();
        return concertEntities;
    }

    public async Task<Concert> GetByIdAsync(Guid id)
    {
        var concert = await dbContext.ConcertEntities
            .AsNoTracking()
            .Include(e => e.Members)
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        return concert;
    }
    
    public async Task<(List<Concert>, int)> GetBySpecificationAsync(ISpecification<Concert> spec, int? page, int? size)
    {
        var query = dbContext.ConcertEntities.AsQueryable();

        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        if (spec.OrderBy != null)
        {
            query = spec.OrderBy(query);
        }

        var countOfEvents = await query.CountAsync();

        if (page.HasValue && size.HasValue)
        {
            query = query.Skip((int)((page - 1) * size)).Take((int)size);
        }

        var events = await query
            .Include(e => e.Members)
            .AsNoTracking()
            .ToListAsync();

        return (events, countOfEvents);
    }
    
    public async Task<Guid> CreateAsync(Concert receivedConcert)
    {
        await dbContext.ConcertEntities.AddAsync(receivedConcert);
        return receivedConcert.Id;
    }
    
    public async Task UpdateAsync(Concert receivedConcert)
    {
        var foundedEvent = await dbContext.ConcertEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == receivedConcert.Id);

        if (foundedEvent != null)
        {
            foundedEvent.Title = receivedConcert.Title;
            foundedEvent.Description = receivedConcert.Description;
            foundedEvent.Date = receivedConcert.Date;
            foundedEvent.LocationId = receivedConcert.LocationId;
            foundedEvent.Category = receivedConcert.Category;
            foundedEvent.MaxNumberOfMembers = receivedConcert.MaxNumberOfMembers;
            foundedEvent.ImageUrl = receivedConcert.ImageUrl;

            dbContext.ConcertEntities.Update(receivedConcert);
        }
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var foundedConcert = await dbContext.ConcertEntities
            .FirstOrDefaultAsync(e => e.Id == id);

        if (foundedConcert != null)
        {
            dbContext.ConcertEntities.Remove(foundedConcert);
        }
    }
}