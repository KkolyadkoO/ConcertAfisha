namespace ConcertAfisha.Core.Models;

public class Concert
{
    public Concert()
    {
    }

    public Concert(Guid id, string title, string description, DateTime date, Guid locationId, Category category, int maxNumberOfMembers, decimal price, string? imageUrl)
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
        LocationId = locationId;
        Category = category;
        MaxNumberOfMembers = maxNumberOfMembers;
        Price = price;
        ImageUrl = imageUrl;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Guid LocationId { get; set; }
    public Category Category { get; set; }
    public int MaxNumberOfMembers { get; set; } = 0;
    public decimal Price { get; set; } = 0;
    public List<Member> Members { get; } = new List<Member>();
    public string? ImageUrl { get; set; }

}