using Microsoft.EntityFrameworkCore;

namespace SchoolDatabaseMVP.Models
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }
    }
}
