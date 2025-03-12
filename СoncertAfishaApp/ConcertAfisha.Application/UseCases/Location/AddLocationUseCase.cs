using AutoMapper;
using ConcertAfisha.Application.DTOs.Location;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.Location;

public class AddLocationUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddLocationUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Execute(LocationRequestDto requestDto)
    {
        var existingLocation = await _unitOfWork.Locations.GetByTitleAsync(requestDto.Title);
        if (existingLocation != null)
        {
            throw new DuplicateException($"Location with title '{requestDto.Title}' already exists."); 
        }
        var location = _mapper.Map<Core.Models.Location>(requestDto);
        
        var id = await _unitOfWork.Locations.AddAsync(location);
        
        await _unitOfWork.Complete();
        
        return id;
    }
}