using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Wedding.Api.Attributes;
using Wedding.Api.Data.Models;
using Wedding.Api.Helpers;
using Wedding.Api.Utilities;


namespace Wedding.Api.Data
{
    public class ApplicationContext(DbContextOptions options) : DbContext(options)
    {
        private readonly IEncryptionHelper _encryptionHelper;

        public ApplicationContext(DbContextOptions options, IEncryptionHelper encryptionHelper) : this(options)
        {
            _encryptionHelper = encryptionHelper;
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Models.Wedding> Weddings { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Apply encryption converter to properties marked with EncryptedAttribute
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var memberInfo = property.PropertyInfo ?? (MemberInfo)property.FieldInfo;
                    if (memberInfo != null && memberInfo.GetCustomAttribute<EncryptedAttribute>() != null)
                    {
                        property.SetValueConverter(new EncryptedConverter(_encryptionHelper));
                    }
                }
            }
        }
    }
}
