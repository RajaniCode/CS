using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityCore.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4360d91a-ad2a-4769-b816-7595f64ce871", "21480dc4-193e-4b4a-b204-72be934f527b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "87b74538-4f5c-4eb8-a765-fab7141db180", 0, "0207a465-7d53-416d-9102-936b6be71536", "e.mail@example.com", true, false, null, null, "E.MAIL@EXAMPLE.COM", "AQAAAAEAACcQAAAAEHf+6MaKvCdgqJ6mNdFnI399ks9hq+f3NqveSXKbsJjc9lOISItRmR8uPhtx8Cz0aQ==", null, false, "489af94f-79db-42cc-9248-f01a93ee5a08", false, "e.mail@example.com" },
                    { "ee89c32a-381d-4775-ab0d-2f881d9c3c61", 0, "63ef4c55-f0de-4133-bec7-2591c6921491", "mail@example.com", true, false, null, null, "MAIL@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJEJQw0IkT3VWpf4uYbhM7WVKqkGifpLOuAjMqG0oF2vprdDdA+lDQBFr4SW/yHk5A==", null, false, "398464e9-04cf-4119-9aa8-002763a10a10", false, "mail@example.com" },
                    { "98fb6848-e5ab-45fb-81b5-189c768b33a4", 0, "0bb9eb9b-8b05-4ec8-b6eb-528cc6a9ddc9", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJfK08ILcNjSenXjtqUkADzsHGPJlXaSHnox9xkFUTdlQ+ZdOePvYo16S9UBEZgVyQ==", null, false, "f7599009-5aa1-467d-8402-3aa25767f587", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4360d91a-ad2a-4769-b816-7595f64ce871", "98fb6848-e5ab-45fb-81b5-189c768b33a4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4360d91a-ad2a-4769-b816-7595f64ce871", "98fb6848-e5ab-45fb-81b5-189c768b33a4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87b74538-4f5c-4eb8-a765-fab7141db180");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee89c32a-381d-4775-ab0d-2f881d9c3c61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4360d91a-ad2a-4769-b816-7595f64ce871");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98fb6848-e5ab-45fb-81b5-189c768b33a4");
        }
    }
}
