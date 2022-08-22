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

        public DbSet<Book> Books { get; set; }
    }
}
// 4
// PM> Enable-Migrations -ContextTypeName BooksDb -MigrationsDirectory DataContexts\BooksMigrations