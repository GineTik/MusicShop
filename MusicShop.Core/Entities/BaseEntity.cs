using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Core.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
    }

    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
