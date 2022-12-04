using AutoMapper;
using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository;
using System.Collections.Generic;

namespace MusicShop.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public CategoryDTO Create(CategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);

            return _mapper.Map<CategoryDTO>(_unitOfWork.Categories.Add(category));
        }

        public bool Delete(int categoryId)
        {

            return _unitOfWork.Categories.Remove(categoryId);
        }

        public CategoryDTO Edit(CategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            return _mapper.Map<CategoryDTO>(_unitOfWork.Categories.Update(category));
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            
            return _mapper.Map<IEnumerable<CategoryDTO>>( _unitOfWork.Categories.GetAll());
        }

        public CategoryDTO GetById(int categoryId)
        {
            return _mapper.Map<CategoryDTO>(_unitOfWork.Categories.GetById(categoryId));
        }
    }
}
