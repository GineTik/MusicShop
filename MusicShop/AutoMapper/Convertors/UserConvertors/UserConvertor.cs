using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Services.HasherServices;
using AutoMapper;

namespace MusicShop.WebHost.AutoMapper.Convertors.UserConvertors
{
    public class UserConvertor : ITypeConverter<UserDTO, User>
    {
        private readonly IPasswordService _passwordService;

        public UserConvertor(IPasswordService passwordService) =>
            _passwordService = passwordService;

        public User Convert(UserDTO source, User destination, ResolutionContext context)
        {
            
            return new User()
            {
                Email = source.Email,
                UserName = source.Username,
                PasswordHash = _passwordService.HashPassword(source),
                EmailConfirmed = false,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };
        }
    }
}
