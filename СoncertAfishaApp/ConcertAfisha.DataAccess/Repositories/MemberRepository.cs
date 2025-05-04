using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess.Repositories;

public class MemberRepository : Repository<Member>, IMemberRepository
{
    public MemberRepository(ConcertAfishaAppDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Member>> GetByConcertIdAsync(Guid concertId)
    {
        return await _dbContext.MemberEntities
            .AsNoTracking()
            .Where(m => m.ConcertId == concertId)
            .ToListAsync();
    }

    public async Task<List<Member>> GetByUserIdAsync(Guid userId)
    {
        return await _dbContext.MemberEntities
            .AsNoTracking()
            .Where(m => m.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Member>> GetByConcertIdAndUserIdAsync(Guid concertId, Guid userId)
    {
        return await _dbContext.MemberEntities
            .AsNoTracking()
            .Where(m => m.ConcertId == concertId && m.UserId == userId)
            .ToListAsync();
    }

    public async Task DeleteByConcertIdAndUserIdAsync(Guid concertId, Guid userId)
    {
        var member = await _dbContext.MemberEntities
            .FirstOrDefaultAsync(m => m.ConcertId == concertId && m.UserId == userId);
        _dbContext.MemberEntities.Remove(member);
    }
}