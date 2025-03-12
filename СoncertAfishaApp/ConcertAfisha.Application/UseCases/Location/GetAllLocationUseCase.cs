using AutoMapper;
using ConcertAfisha.Application.DTOs.Location;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Location;

public class GetAllLocationUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllLocationUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<LocationResponseDto>> Execute()
    {
        var locations = await _unitOfWork.Locations.GetAllAsync();
        return _mapper.Map<List<LocationResponseDto>>(locations);
    }
}