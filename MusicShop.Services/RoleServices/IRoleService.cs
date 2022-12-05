using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.RoleServices
{
    public interface IRoleService
    {
        RoleDTO GetRoleByName(string name);
        RoleDTO GetRoleByUser(UserDTO user);
        RoleDTO GetRoleByUserEmail(string email);
        UserDTO AssignModerRoleToUser(UserDTO user);
        IEnumerable<RoleDTO> GetAllRoles();
        IEnumerable<UserDTO> GetUsersByRole(RoleDTO role);
    }
}
