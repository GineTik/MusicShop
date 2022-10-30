using MusicShop.Core.Entities;

namespace MusicShop.DataAccess.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
