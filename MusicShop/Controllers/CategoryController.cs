using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.CategoryServices;

namespace MusicShop.WebHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("cetById")]
        public IActionResult GetById(int categoryId)
        {
            return Ok(_categoryService.GetById(categoryId));
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpPost("edit")]
        public IActionResult Edit(CategoryDTO dto)
        {
            return Ok(_categoryService.Edit(dto));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CategoryDTO dto)
        {
            return Ok(_categoryService.Create(dto));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}
