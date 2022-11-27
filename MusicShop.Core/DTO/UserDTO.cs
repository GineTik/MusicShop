using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
