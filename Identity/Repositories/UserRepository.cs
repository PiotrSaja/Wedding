using BuildingBlocks.Data;
using Identity.Api.Data;
using Identity.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
    }
    public class UserRepository(ApplicationContext context) : AsyncRepository<User>(context), IUserRepository
    {
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(x=>x.Email == email);
        }
    }
}
