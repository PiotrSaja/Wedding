using Identity.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Identity.Api.Data
{
    public class ApplicationContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
