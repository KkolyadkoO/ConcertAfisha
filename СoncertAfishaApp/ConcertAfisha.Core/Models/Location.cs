namespace ConcertAfisha.Core.Models;

public class Location
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }

    public Location(Guid id, string title, string address, string city, double lat, double lng)
    {
        Id = id;
        Title = title;
        Address = address;
        City = city;
        Lat = lat;
        Lng = lng;
    }

    public Location()
    {
    }
}