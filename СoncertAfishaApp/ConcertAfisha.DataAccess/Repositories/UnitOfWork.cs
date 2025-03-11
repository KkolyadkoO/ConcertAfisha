using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ConcertAfishaAppDBContext _context;

    public IConcertRepository Concerts { get; private set; }
    
    

    public UnitOfWork(ConcertAfishaAppDBContext context)
    {
        _context = context;
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