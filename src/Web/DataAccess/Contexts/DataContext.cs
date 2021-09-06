using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Config;
using Web.DataAccess.Entities;

namespace Web.DataAccess.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new UserRoleConfig());
        }

        public DbSet<UserTable> User { get; set; }
        public DbSet<RoleTable> Role { get; set; }
        public DbSet<UserRoleTable> UserRole { get; set; }
    }
}