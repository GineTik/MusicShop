using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.MusicServices
{
    public interface IMusicService
    {
        
        MusicDTO CreateMusic(MusicDTO dto);
        MusicDTO Update(MusicDTO dto);
        bool DeleteMusic(int musicId);

        IEnumerable<MusicDTO> GetMusicsByCategoryId(int categoryId);
        IEnumerable<MusicDTO> GetMusicsByPriceRange(decimal from, decimal to);
        IEnumerable<MusicDTO> GetMusicsByName(string name);

        IEnumerable<OrderDTO> GetOrdersMusic(MusicDTO music);
        IEnumerable<OrderDTO> GetOrdersMusic(int musicId);

        void SalesOnCategory(CategoryDTO category);
        void SalesOnMusic(MusicDTO music);

        // TODO: Взагалі, потрібна таблиця снижки
        // Снижки як для конкретних пісень, так і для групп ( пісні з спільним аттрибутом )
    }
}
