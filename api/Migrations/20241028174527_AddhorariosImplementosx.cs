using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddhorariosImplementosx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1db608e1-0df7-4c1f-be5d-276009c13598");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba8f0915-52da-40bb-b183-f745aa4c197b");

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Disponible = table.Column<bool>(type: "boolean", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: true),
                    ImplementoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horario_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Horario_Implemento_ImplementoId",
                        column: x => x.ImplementoId,
                        principalTable: "Implemento",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4973a7f1-db55-4ab0-9f4a-8a5f89a982c3", null, "Admin", "ADMIN" },
                    { "79e9b281-849e-46c3-9e7a-df3f037d3fcc", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horario_AreaId",
                table: "Horario",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_ImplementoId",
                table: "Horario",
                column: "ImplementoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4973a7f1-db55-4ab0-9f4a-8a5f89a982c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79e9b281-849e-46c3-9e7a-df3f037d3fcc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1db608e1-0df7-4c1f-be5d-276009c13598", null, "Admin", "ADMIN" },
                    { "ba8f0915-52da-40bb-b183-f745aa4c197b", null, "User", "USER" }
                });
        }
    }
}
