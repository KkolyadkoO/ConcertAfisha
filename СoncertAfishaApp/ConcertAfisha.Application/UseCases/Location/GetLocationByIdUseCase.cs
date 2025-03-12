using AutoMapper;
using ConcertAfisha.Application.DTOs.Location;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Location;

public class GetLocationByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLocationByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LocationResponseDto> Execute(Guid id)
    {
        var location = await _unitOfWork.Locations.GetByIdAsync(id);
        if (location == null)
        {
            throw new NotFoundException($"Location with ID {id} not found.");
        }
        return _mapper.Map<LocationResponseDto>(location);
    }
}