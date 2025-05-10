using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.DTOs.Concert;

public record ConcertsResponseDto(
    Guid Id = default,
    string Title = "",
    string Description = "",
    DateTime Date = default,
    Guid LocationId = default,
    Category Category = default,
    int MaxNumberOfMembers = 0,
    int NumberOfMembers = 0,
    decimal Price = 0,
    string? ImageUrl = null
    );