namespace ConcertAfisha.Core.Models;

public class Location
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Url { get; set; }

    public Location(Guid id, string title, string address, string city, string url)
    {
        Id = id;
        Title = title;
        Address = address;
        City = city;
        Url = url;
    }

    public Location()
    {
    }
}