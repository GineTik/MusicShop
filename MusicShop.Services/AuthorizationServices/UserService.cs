using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.AuthorizationServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, int> _repository;

        public UserService(IRepository<User, int> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public void AddUser(UserDTO user)
        {
            //_repository.Add(new User
            //{
            //    Email = user.Email,
            //    UserName = user.Username,
                


            //});
        }

        public User GetUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
