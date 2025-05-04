using AutoMapper;
using ConcertAfisha.Application.DTOs.Member;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Member;

public class GetAllMembersByConcertIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllMembersByConcertIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<MemberResponseDto>> Execute(Guid concertId)
    {
        var members = await _unitOfWork.Members.GetByConcertIdAsync(concertId);
        return _mapper.Map<List<MemberResponseDto>>(members);
    }
}