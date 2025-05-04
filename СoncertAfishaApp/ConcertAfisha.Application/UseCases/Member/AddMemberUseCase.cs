using AutoMapper;
using ConcertAfisha.Application.DTOs.Member;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Member;

public class AddMemberUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddMemberUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Execute(MemberRequestDto requestDto)
    {
        var memberOfEvent = _mapper.Map<Core.Models.Member>(requestDto); 
        await _unitOfWork.Members.AddAsync(memberOfEvent);
        await _unitOfWork.Complete();
        return memberOfEvent.Id;
    }
}