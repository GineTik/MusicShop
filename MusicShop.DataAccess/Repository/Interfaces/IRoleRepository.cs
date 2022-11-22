using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repository.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        User AssignModer(int userId);

        Role Get(string name);

        Role GetRoleModer();
        Role GetRoleAdmin();
        Role GetRoleUser();

    }
}
