using MusicShop.Core.Entities;
using System.Text.Json.Serialization;

namespace MusicShop.Core.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        //public RoleDTO Role { get; set; }
    }
}
