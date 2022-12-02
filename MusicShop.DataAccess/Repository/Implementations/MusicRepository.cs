using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void AssignDiscountCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        // Ні я не дебіл. Просто категорія приходить до нас з клієнту.
        // І взагалі, то має бути ДТО 
        public IEnumerable<Music> GetMusicsByCategory(Category category)
        {
            return _db.Musics.Where(u => u.CategoryId == category.Id);
        }

        public IEnumerable<Music> GetMusicsByName(string name)
        {
            return _db.Musics.Where(u => u.Name == name);
        }

        public IEnumerable<Music> GetMusicsByPriceRange(decimal from, decimal to)
        {
            return _db.Musics.Where(m => 
                m.Price >= from &&
                m.Price <= to);
        }

        public IEnumerable<Order> GetOrdersMusic(Music music)
        {
            return _db.Orders.Where(or => or.MusicId == music.Id);
        }

        

        public void MusicDiscount(Music music)
        {
            throw new System.NotImplementedException();
        }
    }
}
