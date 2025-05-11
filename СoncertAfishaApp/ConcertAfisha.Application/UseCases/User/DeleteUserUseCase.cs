using AutoMapper;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.User;

public class DeleteUserUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task Execute(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null)
            throw new NotFoundException("User not found");
        
        await _unitOfWork.Users.DeleteAsync(id);
        await _unitOfWork.Complete();
    }
}