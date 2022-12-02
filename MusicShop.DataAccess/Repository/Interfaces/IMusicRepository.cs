using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.DataAccess.Repository.Interfaces
{
    public interface IMusicRepository : IRepository<Music>
    {

        IEnumerable<Music> GetMusicsByCategory(Category category);
        IEnumerable<Music> GetMusicsByName(string name);
        IEnumerable<Music> GetMusicsByPriceRange(decimal from, decimal to);
        IEnumerable<Order> GetOrdersMusic(Music music);
        void AssignDiscountCategory(Category category);
        void MusicDiscount(Music music);

        

    }
}
