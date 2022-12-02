using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.WebHost.AutoMapper.Profiles
{
    public class MusicProfile : Profile
    {
        public MusicProfile()
        {
            CreateMap<MusicDTO, Music>();
        }
    }
}
