using BuildingBlocks.Data;

namespace Wedding.Api.Data.Models
{
    public class Meal : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string AdditionalDescription { get; set; }
    }
}
