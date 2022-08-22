namespace Books.Web.DataContexts.BooksMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Books.Web.DataContexts.BooksDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\BooksMigrations";
        }

        protected override void Seed(Books.Web.DataContexts.BooksDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
// 5
// PM> Add-Migration -ConfigurationTypeName Books.Web.DataContexts.BooksMigrations.Configuration "InitialCreate"