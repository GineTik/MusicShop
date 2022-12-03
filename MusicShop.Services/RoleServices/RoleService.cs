using MusicShop.Core.Entities;
using MusicShop.Core.Exceptions;
using MusicShop.DataAccess.Repository;
using System.Collections.Generic;

namespace MusicShop.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User AssignModerRoleToUser(int userId)
        {
            return _unitOfWork.Roles.AssignModer(userId);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _unitOfWork.Roles.GetAll();
        }

        public Role GetRoleByName(string name)
        {
            return _unitOfWork.Roles.Get(name);
        }

        public Role GetRoleByUserEmail(string email)
        {
            var user = _unitOfWork.Users.GetByEmail(email);
            return _unitOfWork.Roles.GetById(user.Id);
        }

        public Role GetRoleByUserId(int userId)
        {
            var user = _unitOfWork.Users.GetById(userId);
            return _unitOfWork.Roles.GetById(user.Id);
        }

        public IEnumerable<User> GetUsersByRoleName(string name)
        {
            var role = _unitOfWork.Roles.Get(name);

            if (role == null)
                throw new RoleUndefinedException();

            return _unitOfWork.Users.GetUsersByRoleId(role.Id);
        }
    }
}