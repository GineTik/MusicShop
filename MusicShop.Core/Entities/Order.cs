namespace MusicShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public int MusicId { get; set; }
        public Music Music { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
