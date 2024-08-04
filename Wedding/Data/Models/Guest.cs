using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class Guest : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Table? AssociatedTable { get; set; }
        public int Order { get; set; }
    }
}
