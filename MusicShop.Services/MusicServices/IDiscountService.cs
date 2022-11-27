using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.MusicServices
{
    public interface IDiscountService
    {
        Discount Create(DiscountDTO dto);
        bool Remove(int id);
        IEnumerable<Discount> GetAll();
        IEnumerable<Discount> GetAllByUserId(int userId);
        IEnumerable<Discount> GetAllByMusicId(int musicId);
        IEnumerable<Discount> GetAllAvailableDiscountOfUserForMusic(int userId, int musicId);
    }
}
