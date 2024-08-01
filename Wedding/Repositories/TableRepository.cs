using BuildingBlocks.Data;
using Identity.Api.Repositories;
using Wedding.Api.Data;
using Wedding.Api.Data.Models;

namespace Wedding.Api.Repositories
{
    public interface ITableRepository : IAsyncRepository<Table>
    {
    }
    public class TableRepository(ApplicationContext context) : AsyncRepository<Table>(context), ITableRepository
    {
    }
}
