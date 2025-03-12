using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.RefreshToken;

public class GetRefreshTokenUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRefreshTokenUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Core.Models.RefreshToken> Execute(string refreshToken)
    {
        var foundedRefreshToken = await _unitOfWork.RefreshTokens.GetByTokenAsync(refreshToken);
        if (foundedRefreshToken == null)
        {
            throw new NotFoundException($"Refresh token {refreshToken} not found");
        }
        return foundedRefreshToken;
    }
}