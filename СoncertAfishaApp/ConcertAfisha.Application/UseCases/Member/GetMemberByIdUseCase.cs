using AutoMapper;
using ConcertAfisha.Application.DTOs.Member;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Member;

public class GetMemberByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMemberByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<MemberResponseDto>> Execute(Guid id)
    {
        var members = await _unitOfWork.Members.GetByIdAsync(id);
        return _mapper.Map<List<MemberResponseDto>>(members);
    }
}