using BuildingBlocks.Data;

namespace Wedding.Api.Data.Models
{
    public class Guest : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Table? AssociatedTable { get; set; }
    }
}
