using BuildingBlocks.Data;

namespace Wedding.Api.Data.Models
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
