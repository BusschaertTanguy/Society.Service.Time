using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Contexts
{
    public class UniverseDbContext : DbContext
    {
        public UniverseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}