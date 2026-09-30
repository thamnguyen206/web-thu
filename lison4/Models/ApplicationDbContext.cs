using Microsoft.EntityFrameworkCore;

namespace YourProjectName.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}