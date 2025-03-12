using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.RefreshToken;

public class DeleteRefreshTokenUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRefreshTokenUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(string refreshToken)
    {
        var foundedRefreshToken = await _unitOfWork.RefreshTokens.GetByTokenAsync(refreshToken);
        if (foundedRefreshToken == null)
        {
            throw new NotFoundException($"Refresh Token with token {refreshToken} not found");
        }

        await _unitOfWork.RefreshTokens.DeleteByTokenAsync(refreshToken);
        await _unitOfWork.Complete();
    }
}