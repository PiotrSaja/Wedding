using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
