using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IMemberRepository : IRepository<Member>
{
    Task<List<Member>> GetByConcertIdAsync(Guid concertId);
    Task<List<Member>> GetByUserIdAsync(Guid userId);
    Task<List<Member>> GetByConcertIdAndUserIdAsync(Guid concertId, Guid userId);
    Task DeleteByConcertIdAndUserIdAsync(Guid concertId, Guid userId);
}