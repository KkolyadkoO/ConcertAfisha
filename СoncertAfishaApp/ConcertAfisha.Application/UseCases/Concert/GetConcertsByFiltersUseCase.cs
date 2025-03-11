using AutoMapper;
using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Specifications;

namespace ConcertAfisha.Application.UseCases.Concert;

public class GetConcertsByFiltersUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetConcertsByFiltersUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(List<ConcertsResponseDto>, int)> Execute(ConcertFilterRequestDto request)
    {
        var specification = new ConcertSpecification(request.Title, request.LocationId, request.Start, request.End,
            request.Category, request.UserId);
        var result = await _unitOfWork.Concerts.GetBySpecificationAsync(specification, request.Page, request.PageSize);
        return (_mapper.Map<List<ConcertsResponseDto>>(result.Item1), result.Item2);
    }
}