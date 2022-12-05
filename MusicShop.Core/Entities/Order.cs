using MusicShop.Core.DTO.Enums;
using System;

namespace MusicShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public DateTime DateTime { get; set; }

        public int MusicId { get; set; }
        public Music Music { get; set; }
        public int Count { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }



        public StatusOrder Status { get; set; }
    }
}
