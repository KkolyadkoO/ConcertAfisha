using AutoMapper;
using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.Mapping;

public class MappingConcert : Profile
{
    public MappingConcert()
    {
        CreateMap<ConcertRequestDto, Concert>()
            .ConstructUsing(src => new Concert(
                Guid.NewGuid(),
                src.Title,
                src.Description,
                src.Date.ToUniversalTime(),
                src.LocationId,
                src.Category,
                src.MaxNumberOfMembers,
                src.Price,
                null
            ));
        CreateMap<Concert, ConcertsResponseDto>()
            .ForMember(dest => dest.NumberOfMembers,
                opt =>
                    opt.MapFrom(src => src.MaxNumberOfMembers-src.Members.Count));
    }
}