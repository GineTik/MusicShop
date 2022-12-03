using Microsoft.Extensions.DependencyInjection;
using MusicShop.WebHost.AutoMapper.Profiles;

namespace MusicShop.WebHost.ServiceCollectionExtensions
{
    public static class MapperExtensions
    {
        public static void AddMapperDependencies(this IServiceCollection services)
        {
            // adding automappers profiles for DI
            services.AddAutoMapper(typeof(UserProfile), typeof(MusicProfile), typeof(DiscountProfile));
        }
    }
}
