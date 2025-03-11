namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IUnitOfWork
{
    IConcertRepository Concerts { get; }
    void Dispose();
    Task<int> Complete();
}