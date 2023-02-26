using AutoMapper;
using POS.Application.DTO.Request;
using POS.Domain.Entities;

namespace POS.Application.Mappers;

public class UserEcoMappingsProfile : Profile
{
    public UserEcoMappingsProfile()
    {
        CreateMap<UserEcoRequestDto, UserEco>();
        CreateMap<UserEcoRequestDto, UserLocation>()
            .ForMember(dest => dest.IdProvince, opt => opt.MapFrom(src => (short)src.IdProvince));
        CreateMap<UserEcoRequestDto, UserProfile>();
    }
}
