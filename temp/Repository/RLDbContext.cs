using Microsoft.EntityFrameworkCore;
using ReadingLog.Data.Entities;

namespace ReadingLog.Data.Repository
{
    public class RLDbContext : DbContext
    {
        public RLDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
