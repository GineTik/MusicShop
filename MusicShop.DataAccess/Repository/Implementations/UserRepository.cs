using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;
using System.Linq;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) 
            : base(dataContext)
        {
        }

        public User GetByEmail(string email)
        {

            
            return _db.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}
