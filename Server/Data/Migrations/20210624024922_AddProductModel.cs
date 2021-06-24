using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorHostedIdentity.Server.Data.Migrations
{
    public partial class AddProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baa1e214-8926-4478-b37c-3a01c6ff7b92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb90a594-0e76-427b-8956-3e71a1251e56");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cf86b31-bf45-491f-b050-349a0dbaa6f5", "4489a8e3-141e-435b-a937-df81581ff216", "Visitor", "VISITOR" },
                    { "28020553-5e13-4eb6-87a9-bf19f92fec72", "3177ea33-33d9-41c8-bc01-2ff67e039c34", "Administorator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "Supplier" },
                values: new object[,]
                {
                    { new Guid("0102f709-1dd7-40de-af3d-23598c6bbd1f"), "https://ih1.redbubble.net/image.1062161969.4889/mug,travel,x1000,center-pad,1000x1000,f8f8f8.u2.jpg", "Travel Mug", 11.0, "Code Maze" },
                    { new Guid("ac7de2dc-049c-4328-ab06-6cde3ebe8aa7"), "https://ih1.redbubble.net/image.1063377597.4889/ur,mug_lifestyle,square,1000x1000.u2.jpg", "Classic Mug", 22.0, "Code Maze" },
                    { new Guid("d26384cb-64b9-4aca-acb0-4ebb8fc53ba2"), "https://ih1.redbubble.net/image.1063364659.4889/ra,vneck,x1900,101010:01c5ca27c6,front-c,160,70,1000,1000-bg,f8f8f8.u2.jpg", "Code Maze Logo T-Shirt", 20.0, "Code Maze" },
                    { new Guid("b47d4c3c-3e29-49b9-b6be-28e5ee4625be"), "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodie,mens,101010:01c5ca27c6,front,square_three_quarter,x1000-bg,f8f8f8.1u2.jpg", "Pullover Hoodie", 30.0, "Code Maze" },
                    { new Guid("54b2f952-b63e-4cad-8b38-c09955fe4c62"), "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodiez,mens,101010:01c5ca27c6,front,square_three_quarter,1000x1000-bg,f8f8f8.u2.jpg", "Fitted Scoop T-Shirt", 40.0, "Code Maze" },
                    { new Guid("83e0aa87-158f-4e5f-a8f7-e5a98d13e3a5"), "https://ih1.redbubble.net/image.1063364659.4889/ra,fitted_scoop,x2000,101010:01c5ca27c6,front-c,160,143,1000,1000-bg,f8f8f8.u2.jpg", "Zipped Hoodie", 55.0, "Code Maze" },
                    { new Guid("488aaa0e-aa7e-4820-b4e9-5715f0e5186e"), "https://ih1.redbubble.net/image.1062161956.4889/icr,iphone_11_soft,back,a,x1000-pad,1000x1000,f8f8f8.u2.jpg", "iPhone Case & Cover", 25.0, "Code Maze" },
                    { new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), "https://ih1.redbubble.net/image.1062161956.4889/icr,samsung_galaxy_s10_snap,back,a,x1000-pad,1000x1000,f8f8f8.1u2.jpg", "Case & Skin for Samsung Galaxy", 35.0, "Code Maze" },
                    { new Guid("2d3c2abe-85ec-4d1e-9fef-9b4bfea5f459"), "https://ih1.redbubble.net/image.1063329780.4889/mwo,x1000,ipad_2_snap-pad,1000x1000,f8f8f8.u2.jpg", "iPad Case & Skin", 45.0, "Code Maze" },
                    { new Guid("d1f22836-6342-480a-be2f-035eeb010fd0"), "https://ih1.redbubble.net/image.1062161997.4889/clkc,bamboo,white,1000x1000-bg,f8f8f8.u2.jpg", "Wall Clock", 25.0, "Code Maze" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28020553-5e13-4eb6-87a9-bf19f92fec72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cf86b31-bf45-491f-b050-349a0dbaa6f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb90a594-0e76-427b-8956-3e71a1251e56", "42d7cd0f-dd69-4d99-9b15-a21f6a42614f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baa1e214-8926-4478-b37c-3a01c6ff7b92", "561cb08f-1f00-49dc-95d2-57daf4011891", "Administorator", "ADMINISTRATOR" });
        }
    }
}
