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
            throw new NotImplementedException();
        }

        public bool Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category Edit(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
