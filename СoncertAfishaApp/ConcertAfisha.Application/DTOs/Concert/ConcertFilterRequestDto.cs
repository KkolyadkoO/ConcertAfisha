using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.DTOs.Concert;

public record ConcertFilterRequestDto(
    string? Title = null,
    Guid? LocationId = null,
    Category? Category = null,
    DateTime? Start = null,
    DateTime? End = null,
    Guid? UserId = null,
    int? Page = null,
    int? PageSize = null
    );