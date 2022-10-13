using System.Collections.Generic;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.Services.AuthorizationServices
{
    public interface IUserService
    {
        void AddUser(UserDTO user);
        User GetUser(int id);
        IEnumerable<User> GetAll();
    }
}
