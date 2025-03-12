namespace ConcertAfisha.Application.DTOs.User;

public record TokensResponse
(
    string AccessToken,
    string RefreshToken
);