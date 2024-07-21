using BuildingBlocks.Data;
using Wedding.Api.Attributes;

namespace Wedding.Api.Data.Models
{
    public class ApiKey : IEntity
    {
        public int Id { get; set; }
        [Encrypted]
        public string Key { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

    }
}
