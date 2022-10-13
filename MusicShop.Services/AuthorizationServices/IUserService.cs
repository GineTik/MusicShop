using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.Services.AuthorizationServices
{
    public interface IUserService
    {
        void AddUser(UserDTO user);
        User GetUser(UserDTO user);
        IEnumerable<User> GetAll();
    }
}
