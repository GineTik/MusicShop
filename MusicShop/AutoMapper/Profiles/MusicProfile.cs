using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.WebHost.AutoMapper.Profiles
{
    public class MusicProfile : Profile
    {
        public MusicProfile()
        {
           
            CreateMap<Music, MusicDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ReverseMap();
        }
    }
}
