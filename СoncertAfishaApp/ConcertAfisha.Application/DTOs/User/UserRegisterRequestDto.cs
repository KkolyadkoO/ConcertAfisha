namespace ConcertAfisha.Application.DTOs.User;

public record UserRegisterRequestDto(
    string Name,
    string Lastname,
    string Phone,
    string UserEmail,
    string Password,
    string Role
);