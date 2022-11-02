using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace MusicShop.Core.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        

        public IList<Order> Orders { get; set; }
    }
}
