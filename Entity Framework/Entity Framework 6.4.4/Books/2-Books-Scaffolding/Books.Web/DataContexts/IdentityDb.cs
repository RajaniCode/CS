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
    }
}
// 1
// PM > Enable - Migrations - ContextTypeName IdentityDb - MigrationsDirectory DataContexts\IdentityMigrations
