using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.MusicServices
{
    public interface IMusicService
    {
        
        Music CreateMusic(MusicDTO dto);
        Music Update(MusicDTO dto);
        bool DeleteMusic(int musicId);

        IEnumerable<Music> GetMusicsByCategoryId(int categoryId);
        IEnumerable<Music> GetMusicsByPriceRange(decimal from, decimal to);
        IEnumerable<Music> GetMusicsByName(string name);

        IEnumerable<Order> GetOrdersMusic(Music music);
        IEnumerable<Order> GetOrdersMusic(int musicId);

        void SalesOnCategory(Category category);
        void SalesOnMusic(Music music);

        // TODO: Взагалі, потрібна таблиця снижки
        // Снижки як для конкретних пісень, так і для групп ( пісні з спільним аттрибутом )
    }
}
