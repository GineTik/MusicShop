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

        public bool AttachMusicToDiscount(int discountId, int musicId)
        {
            var discount = GetById(discountId);
            discount.Musics.Add(new Music { Id = musicId });
            return _db.SaveChanges() > 0;
        }

        public bool AttachUserToDiscount(int discountId, int userId)
        {
            var discount = GetById(discountId);
            discount.Users.Add(new User { Id = userId });
            return _db.SaveChanges() > 0;
        }

        public IEnumerable<Discount> GetAllAvailableDiscountOfUserForMusic(int userId, int musicId)
        {
            var userDiscounts = GetAllByUserId(userId);
            return userDiscounts.Where(x => x.Musics.Any(m => m.Id == musicId));
        }

        public IEnumerable<Discount> GetAllByMusicId(int musicId)
        {
            return _db.Discounts.Where(x => x.Musics.Any(m => m.Id == musicId));
        }

        public IEnumerable<Discount> GetAllByUserId(int userId)
        {
            return _db.Discounts.Where(x => x.Users.Any(u => u.Id == userId));
        }
    }
}
