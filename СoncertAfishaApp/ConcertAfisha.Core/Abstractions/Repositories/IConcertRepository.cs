using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IConcertRepository
{
    Task<List<Concert>> GetAllAsync();
    Task<Concert> GetByIdAsync(Guid id);
    Task<(List<Concert>, int)> GetBySpecificationAsync(ISpecification<Concert> spec, int? page, int? size);
    Task<Guid> CreateAsync(Concert receivedConcert);
    Task UpdateAsync(Concert receivedConcert);
    Task DeleteAsync(Guid id);
}