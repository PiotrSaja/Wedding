using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface IGuestRepository : IAsyncRepository<Guest>
    {
    }
    public class GuestRepository(ApplicationContext context) : AsyncRepository<Guest>(context), IGuestRepository
    {
    }
}
