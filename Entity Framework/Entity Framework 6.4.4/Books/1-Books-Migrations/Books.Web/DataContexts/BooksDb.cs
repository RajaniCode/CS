using System.Data.Entity;
// Add Reference to Books.Entities project
using Books.Entities;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public BooksDb()
            : base("DefaultConnection")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
// 4
// PM > Enable - Migrations - ContextTypeName BooksDb - MigrationsDirectory DataContexts\BooksMigrations