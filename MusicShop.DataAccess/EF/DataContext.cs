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
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        
        public DataContext(DbContextOptions options) : base(options)
        {
         
        }


        
    }
}
