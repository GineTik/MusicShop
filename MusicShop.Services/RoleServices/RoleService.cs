using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.Core.Exceptions;
using MusicShop.DataAccess.Repository;
using System.Collections.Generic;

namespace MusicShop.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper= mapper;
        }

        public UserDTO AssignModerRoleToUser(UserDTO user)
        {
            return _mapper.Map<UserDTO>( 
                _unitOfWork.Roles.AssignModer(user.Id)
                );
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            return _mapper.Map<IEnumerable<RoleDTO>>(
                _unitOfWork.Roles.GetAll()
                );
        }

        public RoleDTO GetRoleByName(string name)
        {
            return _mapper.Map<RoleDTO>(_unitOfWork.Roles.Get(name));
        }

        public RoleDTO GetRoleByUserEmail(string email)
        {
            return _mapper.Map<RoleDTO>(
                _unitOfWork.Users.GetByEmail(email).Role
                );

        }

        public RoleDTO GetRoleByUser(UserDTO user)
        {
            return GetRoleByUserEmail(user.Email);
        }

        public IEnumerable<UserDTO> GetUsersByRole(RoleDTO role)
        {
            var r = _unitOfWork.Roles.Get(role.Name);

            if (r == null)
                throw new RoleUndefinedException();

            return _mapper.Map<IEnumerable<UserDTO>>( 
                _unitOfWork.Users.GetUsersByRoleId(r.Id)
                );
        }

       
    }
}