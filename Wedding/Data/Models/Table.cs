using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class Table : BaseEntity
    {
        public string Name { get; set; }
        public string Order { get; set; }
    }
}
