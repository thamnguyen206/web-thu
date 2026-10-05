
using lison7.Models;
using Microsoft.EntityFrameworkCore;

namespace lison7.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Lập trình & CNTT" },
                new Category { CategoryId = 2, CategoryName = "Kinh tế & Quản trị" },
                new Category { CategoryId = 3, CategoryName = "Văn học" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "Robert C. Martin", Bio = "Tác giả Clean Code" },
                new Author { AuthorId = 2, AuthorName = "Andrew Hunt", Bio = "Tác giả The Pragmatic Programmer" }
            );
        }
    }
}