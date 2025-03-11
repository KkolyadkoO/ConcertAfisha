using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess.Repositories;

public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(ConcertAfishaAppDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<RefreshToken> GetByTokenAsync(string token)
    {
        return await _dbContext.RefreshTokenEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task<RefreshToken> GetByUserIdAsync(Guid userId)
    {
        return await _dbContext.RefreshTokenEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task DeleteByTokenAsync(string token)
    {
        var refreshToken = await _dbContext.RefreshTokenEntities
            .FirstOrDefaultAsync(rt => rt.Token == token);

        _dbContext.RefreshTokenEntities.Remove(refreshToken);
    }
}