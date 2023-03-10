using Microsoft.EntityFrameworkCore;

namespace BasicAPI.Models
{
    public class DBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DBContext(IConfiguration configuration, DbContextOptions<DBContext> options): base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DBConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<User> Users { get; set; }
    }
}