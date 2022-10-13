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

        public string HashPassword(string password, UserDTO userDTO)
        {
            return _hasher.HashPassword(null, password + userDTO.Email);
        }

        public bool VerifyHashedPassword(string hash, string password, UserDTO userDTO)
        {
            return _hasher.VerifyHashedPassword(null, hash, password + userDTO.Email) == PasswordVerificationResult.Success;
        }
    }
}
