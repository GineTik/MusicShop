using MusicShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;

namespace MusicShop.Core.DTO
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTime ExpirationTime { get; set; }

        public List<int> UsersIds { get; set; }
        public List<int> MusicsIds { get; set; }
    }
}
