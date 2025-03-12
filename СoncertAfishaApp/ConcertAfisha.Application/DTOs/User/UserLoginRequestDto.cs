namespace ConcertAfisha.Application.DTOs.User;

public record UserLoginRequestDto
(
    string? Email,
    string? Phone,
    string Password
);