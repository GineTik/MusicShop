using MusicShop.Core.Entities;
using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Interfaces;

namespace MusicShop.DataAccess.Repository.Implementations
{
    public class CategoryRepository : Repository<Category>, IUserOfWork
    {
        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
