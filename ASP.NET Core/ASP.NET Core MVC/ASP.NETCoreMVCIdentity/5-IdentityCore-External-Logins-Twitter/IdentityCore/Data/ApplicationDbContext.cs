using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roleId = Guid.NewGuid().ToString();
            // Seeding Administrator role to AspNetRoles table
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = roleId, Name = "Admin", NormalizedName = "ADMIN" }); // Id // PRIMARY KEY

            // Hasher to hash password before seeding user to database
            var hasher = new PasswordHasher<IdentityUser>();

            var userId = Guid.NewGuid().ToString();

            // Seeding user to AspNetUsers table
            builder.Entity<IdentityUser>().HasData(
                    new IdentityUser
                    {
                        UserName = "e.mail@example.com",
                        NormalizedUserName = "E.MAIL@EXAMPLE.COM",
                        Email = "e.mail@example.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Hola!123")
                    },
                    new IdentityUser
                    {
                        UserName = "mail@example.com",
                        NormalizedUserName = "MAIL@EXAMPLE.COM",
                        Email = "mail@example.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Hola!123")
                    },
                    new IdentityUser
                    {
                        Id = userId, // PRIMARY KEY
                        UserName = "admin@example.com",
                        NormalizedUserName = "ADMIN@EXAMPLE.COM",
                        Email = "admin@example.com",
                        NormalizedEmail = "ADMIN@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Hola!123")
                    }
            );

            // Seeding relation between user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = roleId, // FOREIGN KEY([RoleId]) REFERENCES[dbo].[AspNetRoles]([Id])
                    UserId = userId
                }
            );
        }
    }
}
// 1
// PM> Add-Migration InitialCreate
// 2
// PM> Update-Database
// OR
// PM> Update-Database -Verbose