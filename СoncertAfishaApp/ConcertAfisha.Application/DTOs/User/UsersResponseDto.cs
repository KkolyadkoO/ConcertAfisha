namespace ConcertAfisha.Application.DTOs.User;

public record UsersResponseDto(
    Guid Id,
    string Name,
    string LastName,
    string Phone,
    string UserEmail,
    string Role
);