using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.EF
{
    public class DataContext : IdentityUserContext<User, int>
    {
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Role> Roles { get; set; }
        
        public DataContext(DbContextOptions options) : base(options)
        {
         
        }


        
    }
}
