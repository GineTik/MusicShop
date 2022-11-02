using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace MusicShop.Core.Entities
{
    public class Music : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IList<Order> Orders { get; set; }
        

    }
}
