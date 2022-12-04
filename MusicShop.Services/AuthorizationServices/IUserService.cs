using System.Collections.Generic;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;

namespace MusicShop.Services.AuthorizationServices
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetAll();

        UserResponse TryLogin(UserDTO dto);
        UserResponse TryRegistration(UserDTO dto);

        OrderDTO OrderMusic(UserDTO user, MusicDTO music);
        void CancleOrderMusic(UserDTO user, MusicDTO music);
        IEnumerable<OrderDTO> GetAllOrders(UserDTO user);
    }
}
