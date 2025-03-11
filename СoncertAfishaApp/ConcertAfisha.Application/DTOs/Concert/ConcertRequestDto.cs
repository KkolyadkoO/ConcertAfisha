using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.DTOs.Concert;

public record ConcertRequestDto(
    string Title,
    string Description,
    DateTime Date,
    Guid LocationId,
    Category Category,
    int MaxNumberOfMembers,
    decimal Price
    );