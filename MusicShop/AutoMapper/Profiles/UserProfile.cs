using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Core.WebHost.DTO;
using MusicShop.WebHost.AutoMapper.Convertors.UserConvertors;

namespace MusicShop.WebHost.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, UserDTO>();
            CreateMap<UserDTO, User>()
                .ConvertUsing<UserConvertor>();
        }
    }
}
