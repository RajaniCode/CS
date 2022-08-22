using System.Data.Entity;
// Install-Package EntityFramework -Version 6.4.4
using Microsoft.AspNet.Identity.EntityFramework;
using Books.Web.Models;

namespace Books.Web.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }

        // 7
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("identity");
            base.OnModelCreating(modelBuilder);
        }
    }
}
// 1
// PM > Enable - Migrations - ContextTypeName IdentityDb - MigrationsDirectory DataContexts\IdentityMigrations
// 7
// PM> Add-Migration -ConfigurationTypeName Books.Web.DataContexts.IdentityMigrations.Configuration "DefaultSchema"
// [
// To re-scaffold the entire migration, use the -Force parameter.
// PM> Add-Migration -ConfigurationTypeName Books.Web.DataContexts.IdentityMigrations.Configuration "DefaultSchema" -Force
//]