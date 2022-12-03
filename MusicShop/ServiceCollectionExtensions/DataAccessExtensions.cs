using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository;

namespace MusicShop.WebHost.ServiceCollectionExtensions
{
    public static class DataAccessExtensions
    {
        public static void AddDataAccessDependencies(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("cs1"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IRoleRepository, RoleRepository>();
            //services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<IMusicRepository, MusicRepository>();
            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<IDiscountRepository, DiscountRepository>();
        }
    }
}