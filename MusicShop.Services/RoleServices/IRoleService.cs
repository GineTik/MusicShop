using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.RoleServices
{
    public interface IRoleService
    {
        Role? GetRoleByName(string name);
        Role? GetRoleByUserId(int userId);
        Role? GetRoleByUserEmail(string email);
        User AssignModerRoleToUser(int userId);
        IEnumerable<Role> GetAllRoles();
        IEnumerable<User> GetUsersByRoleName(string name);
    }
}
