using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string AdditionalDescription { get; set; }
    }
}
