using AutoMapper;
using ConcertAfisha.Application.DTOs.Location;
using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.Mapping;

public class MappingLocation : Profile
{
    public MappingLocation()
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
            .ForMember(dest => dest.Lat,
                opt =>
                    opt.MapFrom(src => src.Lat))
            .ForMember(dest => dest.Lng,
                opt =>
                    opt.MapFrom(src => src.Lng));
        CreateMap<Location, LocationResponseDto>();
    }
}