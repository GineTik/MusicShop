using System.Collections.Generic;

namespace MusicShop.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public IList<Music> Musics { get; set; }
    }
}
