using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface IMealRepository : IAsyncRepository<Meal>
    {
    }
    public class MealRepository(ApplicationContext context) : AsyncRepository<Meal>(context), IMealRepository
    {
    }
}
