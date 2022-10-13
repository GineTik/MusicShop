using MusicShop.Core.DTO;

namespace MusicShop.Services.HasherServices
{
    public interface IPasswordService
    {
        string HashPassword(string password, UserDTO userDTO);
        bool VerifyHashedPassword(string hash, string password, UserDTO userDTO);
    }
}
