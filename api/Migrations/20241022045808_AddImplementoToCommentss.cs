using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddImplementoToCommentss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Area_AreaId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Implemento_ImplementoId",
                table: "Comments");

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
                    { "1db608e1-0df7-4c1f-be5d-276009c13598", null, "Admin", "ADMIN" },
                    { "ba8f0915-52da-40bb-b183-f745aa4c197b", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Area_AreaId",
                table: "Comments",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Implemento_ImplementoId",
                table: "Comments",
                column: "ImplementoId",
                principalTable: "Implemento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Area_AreaId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Implemento_ImplementoId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1db608e1-0df7-4c1f-be5d-276009c13598");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba8f0915-52da-40bb-b183-f745aa4c197b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a71034f-d8d2-40a0-9c45-6474f14bef04", null, "User", "USER" },
                    { "522d2a44-9f43-4d8b-aba1-eb4efb05b44d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Area_AreaId",
                table: "Comments",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Implemento_ImplementoId",
                table: "Comments",
                column: "ImplementoId",
                principalTable: "Implemento",
                principalColumn: "Id");
        }
    }
}
