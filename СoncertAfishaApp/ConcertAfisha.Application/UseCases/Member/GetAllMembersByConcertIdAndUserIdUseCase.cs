using AutoMapper;
using ConcertAfisha.Application.DTOs.Member;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Member;

public class GetAllMembersByConcertIdAndUserIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllMembersByConcertIdAndUserIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<MemberResponseDto>> Execute(Guid concertId, Guid userId)
    {
        var members = await _unitOfWork.Members.GetByConcertIdAndUserIdAsync(concertId, userId);
        return _mapper.Map<List<MemberResponseDto>>(members);
    }
}