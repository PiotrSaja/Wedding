using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class Wedding : BaseEntity
    {
        public string Name { get; set; }
        public List<Guest> GuestList { get; set; }
        public Location Location { get; set; }
        public Menu Menu { get; set; }
        public string Description { get; set; }
        public List<Notification> Notifications { get; set; }
        public ApiKey ApiKey { get; set; }
    }
}
