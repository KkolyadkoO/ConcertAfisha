namespace ConcertAfisha.Application.DTOs.User;

public record UsersResponseDto(
    Guid Id,
    string Name,
    string LastName,
    string UserEmail,
    string Phone,
    string Role
);