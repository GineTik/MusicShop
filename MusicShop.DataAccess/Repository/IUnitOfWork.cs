using MusicShop.DataAccess.Repository.Interfaces;

namespace MusicShop.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IMusicRepository Musics { get; }
        public IUserOfWork Categories { get; }
        public IDiscountRepository Discounts { get; }
        public IOrderRepository Orders { get; }
    }
}
