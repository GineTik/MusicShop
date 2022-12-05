using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(DataContext dataContext) : base(dataContext)
        { }

        public IEnumerable<Discount> GetAllAvailableDiscountOfUserForMusic(int userId, int musicId)
        {
            var userDiscounts = _db.Discounts.Where(x => x.Users.Any(u => u.Id == userId));
            return userDiscounts.Where(x => x.Musics.Any(m => m.Id == musicId));
        }

        public IEnumerable<Discount> GetAllByMusicId(int musicId)
        {
            return _db.Discounts.Where(x => x.Musics.Any(m => m.Id == musicId));
        }

        public IEnumerable<Discount> GetAllByUserId(int userId)
        {
            return _db.Discounts.Where(x => x.UserId == userId);
        }
    }
}
