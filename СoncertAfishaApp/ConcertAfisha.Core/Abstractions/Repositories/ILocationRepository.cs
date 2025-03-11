using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface ILocationRepository : IRepository<Location>
{
    Task<Location> GetByTitle(string title);
}