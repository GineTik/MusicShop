using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {

        public RoleRepository(DataContext db)
            :base(db)
        {
            
        }

        public Role Get(string name) => _db.Roles.FirstOrDefault(r => r.Name == name);

        public Role GetRoleModer() => Get("Moder");
        public Role GetRoleAdmin() => Get("Admin");
        public Role GetRoleUser() => Get("User");

        public User AssignModer(int userId)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            if(user != null)
            {
                user.Role = Get("Moder");
                _db.SaveChanges();
            }

            return user;
        }
    }
}
