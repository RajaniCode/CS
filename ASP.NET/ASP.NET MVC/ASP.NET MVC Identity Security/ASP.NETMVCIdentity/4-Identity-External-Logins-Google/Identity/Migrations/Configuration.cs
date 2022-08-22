using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Edit
            // Traditional EntityFramework approach to seed the database // using Identity.Models; // ApplicationUser // using Microsoft.AspNet.Identity; // PasswordHasher
            var hasher = new PasswordHasher();
            context.Users.AddOrUpdate
            (
                u => u.Email,
                new ApplicationUser { Email = "e.mail@example.com", PasswordHash = hasher.HashPassword("Hola!123"), UserName = "e.mail@example.com", SecurityStamp = Guid.NewGuid().ToString() }
            );

            // Alternate EntityFramework approach to seed the database
            if (!context.Users.Any(u => u.Email == "mail@example.com"))
            {
                // using Microsoft.AspNet.Identity.EntityFramework; // UserStore
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { Email = "mail@example.com", UserName = "mail@example.com", };
                manager.Create(user, "Hola!123");
            }

            // Add User and Role
            IdentityUserAndRole(context);
        }

        public void IdentityUserAndRole(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            // Add role
            var role = roleManager.FindByName("Admin");
            if (role == null)
            {
                role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            // Create user
            var user = userManager.FindByName("admin@example.com");
            if (user == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                };
                userManager.Create(newUser, "Hola!123");
                userManager.AddToRole(newUser.Id, "Admin"); // Add role
            }
        }
    }
}
// 2
// PM> Update-Database
// OR
// PM> Update-Database -Verbose