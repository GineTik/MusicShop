using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Linq;

namespace MusicShop.WebHost.AutoMapper.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<DiscountDTO, Discount>()
                .ForMember(
                    dest => dest.Musics, 
                    opt => opt.MapFrom(src => src.MusicIds.Select(id => new Music { Id = id }))
                );
        }
    }
}
