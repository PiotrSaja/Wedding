using BuildingBlocks.Data;
using Wedding.Api.Attributes;

namespace Wedding.Api.Data.Models
{
    public class Wedding : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Encrypted]
        public int UserId { get; set; }
        public List<Guest> GuestList { get; set; }
        public Location Location { get; set; }
        public Menu Menu { get; set; }
        public string Description { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
