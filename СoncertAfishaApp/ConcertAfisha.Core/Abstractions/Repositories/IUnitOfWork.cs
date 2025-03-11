namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IUnitOfWork
{
    IConcertRepository Concerts { get; }
    ILocationRepository Locations { get; }
    IMemberRepository Members { get; }
    IRefreshTokenRepository RefreshTokens { get; }
    IUserRepository Users { get; }
    void Dispose();
    Task<int> Complete();
}