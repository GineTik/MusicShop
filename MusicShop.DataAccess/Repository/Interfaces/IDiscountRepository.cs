using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.DataAccess.Repository.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        IEnumerable<Discount> GetAllByUserId(int userId);
        IEnumerable<Discount> GetAllByMusicId(int musicId);
        IEnumerable<Discount> GetAllAvailableDiscountOfUserForMusic(int userId, int musicId);
    }
}
