using AutoMapper;
using ConcertAfisha.Application.DTOs.User;
using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.Mapping;

public class MappingUser : Profile
{
    public MappingUser()
    {
        CreateMap<UserRegisterRequestDto, User>()
            .ConstructUsing(src => new User(
                Guid.NewGuid(), 
                src.Name,
                src.Lastname,
                src.Phone,
                src.UserEmail,
                src.Password,
                src.Role
            ));
        CreateMap<User, UsersResponseDto>()
            .ConstructUsing(src=> new UsersResponseDto(
                src.Id,
                src.Name,
                src.Lastname,
                src.UserEmail,
                src.Phone,
                src.Role));
    }
}