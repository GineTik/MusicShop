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

        private readonly DataContext _db;
        public RoleRepository(DataContext db)
            :base(db)
        {
            _db = db;
        }

        
    }
}
