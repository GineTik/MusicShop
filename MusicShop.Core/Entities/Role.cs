using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Core.Entities
{
    public class Role : IdentityRole<int>, IBaseEntity
    {
        public Role(string name)
            : base(name)
        {    
        }

        public List<User> Users { get; set; }
    }
}
