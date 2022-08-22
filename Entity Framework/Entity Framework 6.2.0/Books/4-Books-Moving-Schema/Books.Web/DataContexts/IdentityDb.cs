using Books.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Books.Web.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection", throwIfV1Schema: false)
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
// PM> Enable-Migrations -ContextTypeName IdentityDb -MigrationsDirectory DataContexts\IdentityMigrations
// 7
// PM> Add-Migration -ConfigurationTypeName Books.Web.DataContexts.IdentityMigrations.Configuration "DefaultSchema"
// [
// To re-scaffold the entire migration, use the -Force parameter.
// PM> Add-Migration -ConfigurationTypeName Books.Web.DataContexts.IdentityMigrations.Configuration "DefaultSchema" -Force
// ]