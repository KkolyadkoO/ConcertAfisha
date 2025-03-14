namespace ConcertAfisha.Core.Models;

public class RefreshToken
{
    public RefreshToken(Guid id, Guid userId, string token, DateTime expires)
    {
        Id = id;
        UserId = userId;
        Token = token;
        Expires = expires;
    }
    
    public RefreshToken() { }
    
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
}