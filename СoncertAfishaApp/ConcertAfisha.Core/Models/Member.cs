namespace ConcertAfisha.Core.Models;

public class Member
{
    public Member(Guid id, string email, string phone, Guid userId, Guid concertId)
    {
        Id = id;
        UserId = userId;
        ConcertId = concertId;
        Email = email;
        Phone = phone;
    }

    public Member() { }

    public Guid Id { get; }
    public DateTime DateOfRegistration { get; set; } = DateTime.Now.ToUniversalTime();
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid UserId { get; set; }
    public Guid ConcertId { get; set; }
}