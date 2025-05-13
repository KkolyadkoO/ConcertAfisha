using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ConcertAfishaAppDBContext _context;
    public IConcertRepository Concerts { get; private set; }
    public ILocationRepository Locations { get; private set; }
    public IMemberRepository Members { get; private set; }
    public IRefreshTokenRepository RefreshTokens { get; private set; }
    public IUserRepository Users { get; private set; }
    public UnitOfWork(ConcertAfishaAppDBContext context)
    {
        _context = context;
        Locations = new LocationRepository(_context);
        Members = new MemberRepository(_context);
        RefreshTokens = new RefreshTokenRepository(_context);
        Users = new UserRepository(_context);
        Concerts = new ConcertRepository(_context);
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
}