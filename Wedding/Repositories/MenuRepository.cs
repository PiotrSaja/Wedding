using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface IMenuRepository : IAsyncRepository<Menu>
    {
    }
    public class MenuRepository(ApplicationContext context) : AsyncRepository<Menu>(context), IMenuRepository
    {
    }
}
