using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
