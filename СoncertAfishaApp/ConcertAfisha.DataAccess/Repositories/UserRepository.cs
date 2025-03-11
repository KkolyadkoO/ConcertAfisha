using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertAfisha.DataAccess.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ConcertAfishaAppDBContext dbContext) : base(dbContext) { }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _dbContext.UserEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserEmail == email);
    }
    
    public async Task<User> GetByPhoneAsync(string phone)
    {
        return await _dbContext.UserEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Phone == phone);
    }
}