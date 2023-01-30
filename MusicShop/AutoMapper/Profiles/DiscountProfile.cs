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
            //AllowNullCollections = true;

            CreateMap<DiscountDTO, Discount>()
                .ForMember(
                    dest => dest.Musics,
                    opt => opt.MapFrom(src => src.MusicsIds.Select(id => new Music { Id = id }))
                )
                .ForMember(
                    dest => dest.Users,
                    opt => opt.MapFrom(src => src.UsersIds.Select(id => new User { Id = id }))
                );

            CreateMap<Discount, DiscountDTO>()
                .ForMember(
                    dest => dest.MusicsIds,
                    opt => opt.MapFrom(src => src.Musics.Select(m => m.Id))
                )
                .ForMember(
                    dest => dest.UsersIds,
                    opt => opt.MapFrom(src => src.Users.Select(m => m.Id))
                );
        }
    }
}
