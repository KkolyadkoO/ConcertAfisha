using AutoMapper;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Member;

public class DeleteMemberUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteMemberUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task Execute(Guid id)
    {
        var member = await _unitOfWork.Members.GetByIdAsync(id);
        if (member == null)
            throw new NotFoundException("Member not found");
        
        await _unitOfWork.Members.DeleteAsync(id);
        await _unitOfWork.Complete();
    }
}