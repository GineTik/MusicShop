using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Create(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public bool Delete(int categoryId)
        {
            return _categoryRepository.Remove(categoryId);
        }

        public Category Edit(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryRepository.GetById(categoryId);
        }
    }
}
