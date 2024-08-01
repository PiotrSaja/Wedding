using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface IApiKeyRepository : IAsyncRepository<ApiKey>
    {
    }
    public class ApiKeyRepository(ApplicationContext context) : AsyncRepository<ApiKey>(context), IApiKeyRepository
    {
    }
}
