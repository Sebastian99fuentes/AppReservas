using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddImplementoToComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60a0bc6a-7545-461c-bc64-b4ed4a312d70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "775a7e75-f267-4774-9f4c-8b38d5c1f931");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a71034f-d8d2-40a0-9c45-6474f14bef04", null, "User", "USER" },
                    { "522d2a44-9f43-4d8b-aba1-eb4efb05b44d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a71034f-d8d2-40a0-9c45-6474f14bef04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "522d2a44-9f43-4d8b-aba1-eb4efb05b44d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60a0bc6a-7545-461c-bc64-b4ed4a312d70", null, "Admin", "ADMIN" },
                    { "775a7e75-f267-4774-9f4c-8b38d5c1f931", null, "User", "USER" }
                });
        }
    }
}
