using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository;
using System.Collections.Generic;

namespace MusicShop.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Category Create(CategoryDTO dto)
        {
            var category = new Category()
            {
                Name = dto.Name,
            };
            return _unitOfWork.Categories.Add(category);
        }

        public bool Delete(int categoryId)
        {
            return _unitOfWork.Categories.Remove(categoryId);
        }

        public Category Edit(CategoryDTO dto)
        {
            var category = new Category()
            {
                Name = dto.Name,
            };
            return _unitOfWork.Categories.Update(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _unitOfWork.Categories.GetById(categoryId);
        }
    }
}
