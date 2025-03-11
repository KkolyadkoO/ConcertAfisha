using AutoMapper;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.DTOs.Concert;

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
        var existingEvent = await _unitOfWork.Concerts.GetByIdAsync(id);
        if (existingEvent == null)
        {
            throw new NotFoundException($"Event with id {id} not found");
        }

        var response = _mapper.Map<ConcertsResponseDto>(existingEvent);
        response = response with { NumberOfMembers = existingEvent.Members.Count };
        return response;
    }
}