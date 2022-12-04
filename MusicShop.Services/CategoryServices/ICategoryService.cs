using MusicShop.Core.DTO;
using MusicShop.Core.Entities;
using System.Collections.Generic;

namespace MusicShop.Services.CategoryServices
{
    public interface ICategoryService
    {
        CategoryDTO GetById(int categoryId);
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO Create(CategoryDTO dto);
        bool Delete(int categoryId);
        CategoryDTO Edit(CategoryDTO dto);
    }
}
