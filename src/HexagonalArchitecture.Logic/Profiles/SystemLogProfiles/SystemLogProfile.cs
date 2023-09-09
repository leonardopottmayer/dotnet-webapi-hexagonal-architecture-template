using AutoMapper;
using HexagonalArchitecture.Domain.Entities;
using HexagonalArchitecture.Domain.Models.SystemLogModels;

namespace HexagonalArchitecture.Logic.Profiles.SystemLogProfiles
{
    public class SystemLogProfile : Profile
    {
        public SystemLogProfile()
        {
            CreateMap<SystemLog, CreateSystemLogDto>()
                .ReverseMap()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        }
    }
}
