using Microsoft.EntityFrameworkCore;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext)
            : base(dataContext)
        { }

        public User GetByEmail(string email)
        {
            return _db.Users.Include(u => u.Role).FirstOrDefault(x => x.Email == email);
        }

        public IEnumerable<User> GetUsersByRoleId(int roleId)
        {
            return _db.Users.Where(u => u.RoleId == roleId);
        }
    }
}
