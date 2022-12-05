using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.WebHost.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
