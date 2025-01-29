using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c0a2cc6-c8c9-4809-9969-1485b3585f0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8d1ff4-d574-4954-b0e6-186a3a9522e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "97e5de5a-f30e-4b53-83f5-f07559756eb1", null, "User", "USER" },
                    { "9a76f8e2-ba41-4d99-81b5-067e68797161", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97e5de5a-f30e-4b53-83f5-f07559756eb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a76f8e2-ba41-4d99-81b5-067e68797161");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c0a2cc6-c8c9-4809-9969-1485b3585f0b", null, "User", "USER" },
                    { "2a8d1ff4-d574-4954-b0e6-186a3a9522e2", null, "Admin", "ADMIN" }
                });
        }
    }
}
