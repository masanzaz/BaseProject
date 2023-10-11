using BaseProject.Domain.Entities;
using BaseProject.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BaseProject.Infrastructure.Persistence
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        internal virtual DbSet<SeedingEntry> SeedingEntries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}