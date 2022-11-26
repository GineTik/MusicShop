using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.CategoryServices
{
    public interface ICategoryService
    {
        Category GetById(int categoryId);
        IEnumerable<Category> GetAll();
        Category Create(Category category);
        bool Delete(int categoryId);
        Category Edit(Category category);
    }
}
