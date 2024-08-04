using BuildingBlocks.Data;
using Wedding.Api.Attributes;

namespace Wedding.Api.Data.Models.Base
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        [Encrypted]
        public string UserId { get; set; }
    }
}
