using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.Core.Entities;
using MusicShop.Services.AuthorizationServices;
using MusicShop.Services.CategoryServices;
using MusicShop.Services.EmailServices;
using MusicShop.Services.HasherServices;
using MusicShop.Services.MusicServices;
using MusicShop.Services.RoleServices;
using MusicShop.Services.Utils;

namespace MusicShop.WebHost.ServiceCollectionExtensions
{
    public static class ServicesExtensions
    {
        public static void AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<IMusicService, MusicService>();

            services.AddTransient<EmailSender>(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                return new EmailSender(
                    configuration["Google:accountForSMTP:Email"],
                    configuration["Google:accountForSMTP:Password"],
                    "MusicShop");
            });
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
