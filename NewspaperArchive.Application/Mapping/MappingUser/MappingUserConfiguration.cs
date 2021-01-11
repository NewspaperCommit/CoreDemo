using AutoMapper;
using NewspaperArchive.Application.Common.DTO;
using NewspaperArchive.Domain.Entities.Users;

namespace NewspaperArchive.Application.Mapping.MappingUser
{
   public class MappingUserConfiguration:Profile
    {      
       public MappingUserConfiguration()
        {
            CreateMap<User, GetUserDetailDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ScreenName, opt => opt.MapFrom(src => src.ScreenName))
                .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<User, GetUserDetailDTO>().ReverseMap();

           
        }

    }
}
