using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace MusicShop.Core.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public IList<Discount> Discounts { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
