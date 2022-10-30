using MusicShop.Core.DTO;

namespace MusicShop.Services.HasherServices
{
    public interface IPasswordService
    {
        string HashPassword(UserDTO userDTO);
        bool VerifyHashedPassword(string hash, UserDTO userDTO);
    }
}
