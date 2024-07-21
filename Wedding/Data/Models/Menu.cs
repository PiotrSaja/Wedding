using BuildingBlocks.Data;

namespace Wedding.Api.Data.Models
{
    public class Menu : IEntity
    {
        public int Id { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
