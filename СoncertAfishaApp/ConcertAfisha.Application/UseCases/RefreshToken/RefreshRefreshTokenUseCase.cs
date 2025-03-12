using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Auth;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.RefreshToken;

public class RefreshRefreshTokenUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenService _jwtTokenService;

    public RefreshRefreshTokenUseCase(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService)
    {
        _unitOfWork = unitOfWork;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<(string, string)> Execute(string refreshToken)
    {
        var storedRefreshToken = await _unitOfWork.RefreshTokens.GetByTokenAsync(refreshToken);
        if (storedRefreshToken == null)
        {
            throw new NotFoundException($"Refresh Token with token {refreshToken} not found");
        }

        if (storedRefreshToken.Expires < DateTime.Now)
        {
            throw new InvalidCastException("Invalid or expired refresh token");
        }

        var user = await _unitOfWork.Users.GetByIdAsync(storedRefreshToken.UserId);
        if (user == null)
        {
            throw new NotFoundException($"User with id {storedRefreshToken.UserId} not found");
        }
        var tokens = await _jwtTokenService.GenerateToken(user.Id, user.Role);
        await _unitOfWork.Complete();

        return (tokens.accessToken, tokens.refreshToken);
    }
}