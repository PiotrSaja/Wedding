using Wedding.Api.Attributes;
using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class ApiKey : BaseEntity
    {
        [Encrypted]
        public string Key { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
