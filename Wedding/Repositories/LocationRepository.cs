using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface ILocationRepository : IAsyncRepository<Location>
    {
    }
    public class LocationRepository(ApplicationContext context) : AsyncRepository<Location>(context), ILocationRepository
    {
    }
}
