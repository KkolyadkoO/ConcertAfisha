using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Concert;

public class DeleteConcertUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteConcertUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var existingConcert = await _unitOfWork.Concerts.GetByIdAsync(id);
        if (existingConcert == null)
        {
            throw new NotFoundException("Concert not found");
        }

        await _unitOfWork.Concerts.DeleteAsync(id);
        await _unitOfWork.Complete();
    }
}