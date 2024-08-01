using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;

namespace Wedding.Api.Repositories
{
    public interface IWeddingRepository : IAsyncRepository<Data.Models.Wedding>
    {
    }
    public class WeddingRepository(ApplicationContext context) : AsyncRepository<Data.Models.Wedding>(context), IWeddingRepository
    {
    }
}
