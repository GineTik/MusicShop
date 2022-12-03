using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.Services.Validators;

namespace MusicShop.WebHost.ServiceCollectionExtensions
{
    public static class ValidationExtensions
    {
        public static void AddValidationDependencies(this IServiceCollection services)
        {
            // adding validators
            services.AddValidatorsFromAssemblyContaining<UserDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<MusicDTOValidator>();
        }
    }
}
