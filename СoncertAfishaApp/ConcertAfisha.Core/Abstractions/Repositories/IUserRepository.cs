using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByPhoneAsync(string phone);
}