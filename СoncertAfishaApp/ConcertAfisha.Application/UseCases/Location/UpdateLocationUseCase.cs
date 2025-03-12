using AutoMapper;
using ConcertAfisha.Application.DTOs.Location;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Location;

public class UpdateLocationUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLocationUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Execute(Guid id, LocationRequestDto requestDto)
    {
        var location = await _unitOfWork.Locations.GetByIdAsync(id);
        
        if (location == null)
        {
            throw new NotFoundException($"Location with ID '{id}' not found.");
        }
        var updateLocation = _mapper.Map<Core.Models.Location>(requestDto);
        updateLocation.Id = id;
        await _unitOfWork.Locations.UpdateAsync(updateLocation);
        await _unitOfWork.Complete();

        return id;
    }
}