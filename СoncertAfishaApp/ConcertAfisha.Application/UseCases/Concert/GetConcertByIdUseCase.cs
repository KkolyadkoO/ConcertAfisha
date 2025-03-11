using AutoMapper;
using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Specifications;

namespace ConcertAfisha.Application.UseCases.Concert;

public class GetConcertByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetConcertByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ConcertsResponseDto> Execute(Guid id)
    {
        var existing = await _unitOfWork.Concerts
            .GetByIdAsync(id);
        if (existing == null)
        {
            throw new NotFoundException($"Concert with ID {id} not found");
        }
        
        var response = _mapper.Map<ConcertsResponseDto>(existing);
        response = response with{NumberOfMembers = existing.Members.Count};
        return response;
    }
}