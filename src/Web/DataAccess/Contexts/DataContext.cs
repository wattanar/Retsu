using Microsoft.EntityFrameworkCore;
using src.Web.DataAccess.Config;
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
        }

        public DbSet<User> User { get; set; }
    }
}