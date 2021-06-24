using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorHostedIdentity.Server.Data.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb90a594-0e76-427b-8956-3e71a1251e56", "42d7cd0f-dd69-4d99-9b15-a21f6a42614f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baa1e214-8926-4478-b37c-3a01c6ff7b92", "561cb08f-1f00-49dc-95d2-57daf4011891", "Administorator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baa1e214-8926-4478-b37c-3a01c6ff7b92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb90a594-0e76-427b-8956-3e71a1251e56");
        }
    }
}
