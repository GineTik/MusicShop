using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.DTO;
using MusicShop.Services.MusicServices;

namespace MusicShop.WebHost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("create")]
        public IActionResult Create(DiscountDTO user)
        {
            var result = _discountService.Create(user);
            return Ok(result);
        }

        [HttpPost("attachToUser")]
        public IActionResult AttachToUser(int userId, int discountId)
        {
            var result = _discountService.AttachUserToDiscount(userId, discountId);
            return Ok(result);
        }

        [HttpPost("attachToMusic")]
        public IActionResult AttachToMusic(int musicId, int discountId)
        {
            var result = _discountService.AttachMusicToDiscount(musicId, discountId);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_discountService.GetAll());
        }
    }
}
