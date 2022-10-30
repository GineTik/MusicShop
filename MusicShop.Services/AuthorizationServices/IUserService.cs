using System.Collections.Generic;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Core.WebHost.DTO;

namespace MusicShop.Services.AuthorizationServices
{
    public interface IUserService
    {
        User AddUser(UserDTO dto);
        User GetUser(int id);
        IEnumerable<User> GetAll();

        UserResponse TryLogin(UserDTO dto);
        UserResponse TryRegistration(UserDTO dto);
    }
}
