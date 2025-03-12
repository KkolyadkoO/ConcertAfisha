using AutoMapper;
using ConcertAfisha.Application.DTOs.Location;
using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.Mapping;

public class MappingLocation : Profile
{
    protected MappingLocation()
    {
        CreateMap<LocationRequestDto, Location>()
            .ForMember(dest => dest.Id,
                opt =>
                    opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Title,
                opt =>
                    opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Address,
                opt =>
                    opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.City,
                opt =>
                    opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Url,
                opt =>
                    opt.MapFrom(src => src.Url));
        CreateMap<Location, LocationResponseDto>();
    }
}