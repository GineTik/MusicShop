using MusicShop.Core.Entities;

namespace MusicShop.Core.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
