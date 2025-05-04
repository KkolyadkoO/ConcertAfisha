namespace ConcertAfisha.Application.DTOs.Member;

public record MemberResponseDto(
    Guid Id,
    string Email,
    string Phone,
    Guid UserId,
    Guid ConcertId
);