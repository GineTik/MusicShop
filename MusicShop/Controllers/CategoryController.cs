using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.Entities;
using MusicShop.DataAccess.Repository.Interfaces;
using MusicShop.Services.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Edit(Category category)
        {
            return Ok(_categoryService.Edit(category));
        }

        [HttpPost("create")]
        public IActionResult Create(Category category)
        {
            return Ok(_categoryService.Create(category));
        }
    }
}
