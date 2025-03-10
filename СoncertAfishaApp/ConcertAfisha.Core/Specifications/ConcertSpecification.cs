using System.Linq.Expressions;
using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Core.Specifications;

public class ConcertSpecification : BaseSpecification<Concert>
{
    public ConcertSpecification(string? title, Guid? locationId, DateTime? startDate, DateTime? endDate,
        Category? category, Guid? userId)
        : base(e => 
            (string.IsNullOrEmpty(title) || e.Title.ToLower().Contains(title.ToLower())) &&
            (!locationId.HasValue || e.LocationId == locationId.Value) &&
            (!category.HasValue || e.Category == category.Value) &&
            (!startDate.HasValue || e.Date >= startDate.Value) &&
            (!endDate.HasValue || e.Date <= endDate.Value) &&
            (!userId.HasValue || e.Members.Any(m => m.UserId == userId.Value))
        )
    {
        AddOrderBy(q => q.OrderBy(e => e.Date));
    }
}