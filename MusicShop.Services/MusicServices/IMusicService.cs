using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.MusicServices
{
    public interface IMusicService
    {
        
        Music CreateMusic(Music music);
        bool DeleteMusic(int musicId);
        Music Update(Music music);

        IEnumerable<Music> GetMusicsByCategory(Category category);
        IEnumerable<Music> GetMusicsByPriceRange(decimal from, decimal to);
        IEnumerable<Music> GetMusicsByName(string name);

        IEnumerable<Order> GetOrdersMusic(Music music);
        IEnumerable<Order> GetOrdersMusic(int musicId);

        void SalesOnCategory(Category category);
        void SalesOnMusic(Music music);

        bool Buy(int musicId, List<int> discountsIds);
        
        // TODO: Взагалі, потрібна таблиця снижки
        // Снижки як для конкретних пісень, так і для групп ( пісні з спільним аттрибутом )
    }
}
