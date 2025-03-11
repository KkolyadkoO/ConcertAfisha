using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task<RefreshToken> GetByTokenAsync(string token);
    Task<RefreshToken> GetByUserIdAsync(Guid userId);
    Task DeleteByTokenAsync(string token);
}