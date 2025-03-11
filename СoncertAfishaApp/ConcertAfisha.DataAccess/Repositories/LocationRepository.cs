using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess.Repositories;

public class LocationRepository : Repository<Location>, ILocationRepository
{
    public LocationRepository(ConcertAfishaAppDBContext dbContext) : base(dbContext){}

    public async Task<Location> GetByTitle(string title)
    {
        return await _dbContext.LocationEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Title == title);
    }
}