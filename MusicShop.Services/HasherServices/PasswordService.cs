using Microsoft.AspNetCore.Identity;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.Services.HasherServices
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordHasher<User> _hasher;

        public PasswordService(IPasswordHasher<User> hasher)
        {
            _hasher = hasher;
        }

        public string HashPassword(UserDTO dto)
        {
            return _hasher.HashPassword(null, dto.Password + dto.Email);
        }

        public bool VerifyHashedPassword(string hash, UserDTO dto)
        {
            return _hasher.VerifyHashedPassword(null, hash, dto.Password + dto.Email) == PasswordVerificationResult.Success;
        }
    }
}
