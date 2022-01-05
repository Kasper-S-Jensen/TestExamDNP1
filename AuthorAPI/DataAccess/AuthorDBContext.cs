using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.DataAccess
{
    public class AuthorDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Authors.db");
        }
    }
}