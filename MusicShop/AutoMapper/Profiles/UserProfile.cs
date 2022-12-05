using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.WebHost.AutoMapper.Convertors.UserConvertors;

namespace MusicShop.WebHost.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, UserDTO>().ReverseMap();
            CreateMap<UserDTO, User>()
                .ConvertUsing<UserConvertor>();
            CreateMap<User, UserDTO>();
        }
    }
}
