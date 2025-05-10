using AutoMapper;
using ConcertAfisha.Application.DTOs.Member;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Member;

public class GetAllMembers
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllMembers(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<MemberResponseDto>> Execute()
    {
        var members = await _unitOfWork.Members.GetAllAsync();
        return _mapper.Map<List<MemberResponseDto>>(members);
    }
}