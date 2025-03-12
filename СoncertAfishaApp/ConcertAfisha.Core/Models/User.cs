namespace ConcertAfisha.Core.Models;

public class User
{
    public User(Guid id, string name, string lastname, string phone,string password, string role)
    {
        Id = id;
        Name = name;
        Lastname = lastname;
        Phone = phone;
        Role = role;
        Password = password;
    }

    public User() { }
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Phone { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = "user";
    public List<Member> Members { get; } = [];
}