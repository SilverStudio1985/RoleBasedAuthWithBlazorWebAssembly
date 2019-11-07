using Microsoft.EntityFrameworkCore.Migrations;

namespace RoleBasedAuthWithBlazorWebAssembly.Server.Data.Migations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e0bce50-15a5-425b-b8c7-49b8ef48e13c", "8a30b81c-c4d8-4625-bc04-157560f9a758", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bccb2561-85e2-46f4-8bbc-3cef733e5635", "2661701f-af72-4e9f-a014-1990ebdc500e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e0bce50-15a5-425b-b8c7-49b8ef48e13c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bccb2561-85e2-46f4-8bbc-3cef733e5635");
        }
    }
}
