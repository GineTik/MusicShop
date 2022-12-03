using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.DataAccess.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        IEnumerable<User> GetUsersByRoleId(int roleId);
    }
}
