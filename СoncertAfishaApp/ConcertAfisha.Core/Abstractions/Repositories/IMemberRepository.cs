using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IMemberRepository
{
    Task<List<Member>> GetByConcertIdAsync(Guid concertId);
    Task<List<Member>> GetByUserIdAsync(Guid userId);
    Task DeleteByConcertIdAndUserIdAsync(Guid concertId, Guid userId);
}