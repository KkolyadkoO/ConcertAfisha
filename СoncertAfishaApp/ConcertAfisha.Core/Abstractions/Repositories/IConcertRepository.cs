using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IConcertRepository : IRepository<Concert>
{
    Task<(List<Concert>, int)> GetBySpecificationAsync(ISpecification<Concert> spec, int? page, int? size);
}