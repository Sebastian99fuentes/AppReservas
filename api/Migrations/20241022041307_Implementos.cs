using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Implementos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f1916c6-3969-482c-bc3f-1807b64dfcd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "521a7dd8-ea79-489e-979a-9a7dab786fdf");

            migrationBuilder.AddColumn<int>(
                name: "ImplementoId",
                table: "Comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Implemento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreImple = table.Column<string>(type: "text", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implemento", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60a0bc6a-7545-461c-bc64-b4ed4a312d70", null, "Admin", "ADMIN" },
                    { "775a7e75-f267-4774-9f4c-8b38d5c1f931", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ImplementoId",
                table: "Comments",
                column: "ImplementoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Implemento_ImplementoId",
                table: "Comments",
                column: "ImplementoId",
                principalTable: "Implemento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Implemento_ImplementoId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Implemento");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ImplementoId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60a0bc6a-7545-461c-bc64-b4ed4a312d70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "775a7e75-f267-4774-9f4c-8b38d5c1f931");

            migrationBuilder.DropColumn(
                name: "ImplementoId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f1916c6-3969-482c-bc3f-1807b64dfcd7", null, "User", "USER" },
                    { "521a7dd8-ea79-489e-979a-9a7dab786fdf", null, "Admin", "ADMIN" }
                });
        }
    }
}
