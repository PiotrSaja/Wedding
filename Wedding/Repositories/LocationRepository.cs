using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface ILocationRepository : IAsyncRepository<Location>
    {
        Task<IEnumerable<Location>> GetLocationsByUserId(string userId);
    }
    public class LocationRepository(ApplicationContext context) : AsyncRepository<Location>(context), ILocationRepository
    {
        public async Task<IEnumerable<Location>> GetLocationsByUserId(string userId)
        {
            return await _context.Set<Location>().Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
