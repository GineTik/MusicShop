using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.MusicServices
{
    public interface IDiscountService
    {
        DiscountDTO Create(DiscountDTO dto);
        bool Remove(DiscountDTO discount);
        IEnumerable<DiscountDTO> GetAll();
        IEnumerable<DiscountDTO> GetAllByUser(UserDTO user);
        IEnumerable<DiscountDTO> GetAllByMusicId(MusicDTO music);
        IEnumerable<DiscountDTO> GetAllAvailableDiscountOfUserForMusic(UserDTO user, MusicDTO music);
    }
}
