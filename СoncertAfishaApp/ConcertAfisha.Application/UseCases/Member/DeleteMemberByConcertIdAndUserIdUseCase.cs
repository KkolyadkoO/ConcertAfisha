using AutoMapper;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Member;

public class DeleteMemberByConcertIdAndUserIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteMemberByConcertIdAndUserIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task Execute(Guid concertId, Guid userId)
    {
        var member = await _unitOfWork.Members.GetByConcertIdAndUserIdAsync(concertId, userId);
        if (member == null)
            throw new NotFoundException("Members not found");
        
        await _unitOfWork.Members.DeleteByConcertIdAndUserIdAsync(concertId, userId);
        await _unitOfWork.Complete();
    }
}