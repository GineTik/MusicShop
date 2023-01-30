using MusicShop.Core.Entities.Enums;
using MusicShop.Core.Entities.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Core.Entities
{
    public class Discount : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal Amount { get; set; }

        public DiscountType DiscountType { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [GreaterThanUtcNow]
        public DateTime ExpirationDate { get; set; }

        public IList<User> Users { get; set; } = new List<User>();
        public IList<Music> Musics { get; set; } = new List<Music>();
    }
}