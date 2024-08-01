using BuildingBlocks.Data;

namespace Wedding.Api.Data.Models
{
    public class Table :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
