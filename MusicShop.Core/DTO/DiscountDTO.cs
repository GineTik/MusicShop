using MusicShop.Core.Entities.Enums;
using System.Collections.Generic;

namespace MusicShop.Core.DTO
{
    public class DiscountDTO
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DiscountType DiscountType { get; set; }
        
        public int UserId { get; set; }
        public List<int> MusicIds { get; set; }
    }
}
