using Books.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public BooksDb()
            : base("DefaultConnection")
        {

        }

        // 9
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("library");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
// 4
// PM> Enable-Migrations -ContextTypeName BooksDb -MigrationsDirectory DataContexts\BooksMigrations
// 9
// PM> Add-Migration -ConfigurationTypeName Books.Web.DataContexts.BooksMigrations.Configuration "DefaultSchema"
// [
// To re-scaffold the entire migration, use the -Force parameter.
// PM> Add-Migration -ConfigurationTypeName Books.Web.DataContexts.BooksMigrations.Configuration "DefaultSchema" -Force
// ] 