using System.Linq.Expressions;
using BuildingBlocks.Data;
using Microsoft.EntityFrameworkCore;
using Wedding.Api.Data;

namespace Identity.Api.Repositories
{
    public class AsyncRepository<T>(ApplicationContext context) : IAsyncRepository<T> where T : class, IEntity
    {
        protected readonly ApplicationContext _context = context;
        public async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => _context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().CountAsync(predicate);
    }
}
