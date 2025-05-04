namespace ConcertAfisha.Application.DTOs.Member;

public record MemberRequestDto(
    string Email,
    string Phone,
    Guid UserId,
    Guid ConcertId
    );