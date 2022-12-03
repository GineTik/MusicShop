using MusicShop.DataAccess.EF;
using MusicShop.DataAccess.Repository.Implementations;
using MusicShop.DataAccess.Repository.Interfaces;
using System;

namespace MusicShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext _dataContext;

        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IMusicRepository _musicRepository;
        private IUserOfWork _categoryRepository;
        private IDiscountRepository _discountRepository;
        private IOrderRepository _orderRepository;

        public IUserRepository Users => _userRepository ?? (_userRepository = new UserRepository(_dataContext));
        public IRoleRepository Roles => _roleRepository ?? (_roleRepository = new RoleRepository(_dataContext));
        public IMusicRepository Musics => _musicRepository ?? (_musicRepository = new MusicRepository(_dataContext));
        public IUserOfWork Categories => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_dataContext));
        public IDiscountRepository Discounts => _discountRepository ?? (_discountRepository = new DiscountRepository(_dataContext));
        public IOrderRepository Orders => _orderRepository ?? (_orderRepository = new OrderRepository(_dataContext));

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}