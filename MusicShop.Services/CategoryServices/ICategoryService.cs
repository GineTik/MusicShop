using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.CategoryServices
{
    public interface ICategoryService
    {
        Category GetById(int categoryId);
        IEnumerable<Category> GetAll();
        Category Create(CategoryDTO dto);
        bool Delete(int categoryId);
        Category Edit(CategoryDTO dto);
    }
}
