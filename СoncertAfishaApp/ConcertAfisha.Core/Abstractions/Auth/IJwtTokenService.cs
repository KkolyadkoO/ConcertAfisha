namespace ConcertAfisha.Core.Abstractions.Auth;

public interface IJwtTokenService
{
    Task<(string accessToken, string refreshToken)> GenerateToken(Guid userId,
        string role);

    string GenerateRefreshToken();
}