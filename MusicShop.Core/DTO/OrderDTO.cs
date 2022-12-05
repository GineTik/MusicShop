using MusicShop.Core.DTO.Enums;
using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Core.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public MusicDTO Music { get; set; }
        public int Count { get; set; }

        public int UserId { get; set; }


        public StatusOrder Status { get; set; }

    }
}
