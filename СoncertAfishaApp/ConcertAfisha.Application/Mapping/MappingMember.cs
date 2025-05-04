using AutoMapper;
using ConcertAfisha.Application.DTOs.Member;
using ConcertAfisha.Core.Models;

namespace ConcertAfisha.Application.Mapping;

public class MappingMember : Profile
{
    public MappingMember()
    {
        CreateMap<MemberRequestDto, Member>()
            .ConstructUsing(src => new Member(
                Guid.NewGuid(), 
                src.Email,
                src.Phone,
                src.UserId,
                src.ConcertId
            ));
        CreateMap<Member, MemberResponseDto>();
    }
}