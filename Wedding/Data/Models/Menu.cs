using Wedding.Api.Data.Models.Base;

namespace Wedding.Api.Data.Models
{
    public class Menu : BaseEntity
    {
        public List<Meal> Meals { get; set; }
    }
}
