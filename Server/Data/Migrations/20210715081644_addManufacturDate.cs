using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorHostedIdentity.Server.Data.Migrations
{
    public partial class addManufacturDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28020553-5e13-4eb6-87a9-bf19f92fec72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cf86b31-bf45-491f-b050-349a0dbaa6f5");

            migrationBuilder.AlterColumn<string>(
                name: "Supplier",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ManufactureDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dd0328cb-5cd2-49c5-93a7-0cf4f7ccc526", "bfc8d44c-bb59-44c5-ba2c-ec87dda8f0e5", "Visitor", "VISITOR" },
                    { "88da663f-d7dc-4e37-b518-2b7991605fd9", "86ce7b5b-d4d1-41b6-993f-c614b68a892b", "Administorator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0102f709-1dd7-40de-af3d-23598c6bbd1f"),
                column: "ManufactureDate",
                value: new DateTime(2019, 11, 15, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d3c2abe-85ec-4d1e-9fef-9b4bfea5f459"),
                column: "ManufactureDate",
                value: new DateTime(2018, 8, 2, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("488aaa0e-aa7e-4820-b4e9-5715f0e5186e"),
                column: "ManufactureDate",
                value: new DateTime(2019, 11, 10, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4e693871-788d-4db4-89e5-dd7678db975e"),
                column: "ManufactureDate",
                value: new DateTime(2021, 2, 11, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54b2f952-b63e-4cad-8b38-c09955fe4c62"),
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 23, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83e0aa87-158f-4e5f-a8f7-e5a98d13e3a5"),
                column: "ManufactureDate",
                value: new DateTime(2017, 4, 15, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac7de2dc-049c-4328-ab06-6cde3ebe8aa7"),
                column: "ManufactureDate",
                value: new DateTime(2016, 8, 22, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b47d4c3c-3e29-49b9-b6be-28e5ee4625be"),
                column: "ManufactureDate",
                value: new DateTime(2021, 3, 14, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f22836-6342-480a-be2f-035eeb010fd0"),
                column: "ManufactureDate",
                value: new DateTime(2016, 8, 30, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d26384cb-64b9-4aca-acb0-4ebb8fc53ba2"),
                column: "ManufactureDate",
                value: new DateTime(2019, 5, 3, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "ManufactureDate", "Name", "Price", "Supplier" },
                values: new object[] { new Guid("5567d5ac-6b3e-4627-b6c9-cd245f85b845"), "https://localhost:6001/StaticFiles/Images/shockzHomePicture.jpg", new DateTime(2020, 10, 23, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887), "shockz Home", 999999999999.0, "ironPot42.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88da663f-d7dc-4e37-b518-2b7991605fd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd0328cb-5cd2-49c5-93a7-0cf4f7ccc526");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5567d5ac-6b3e-4627-b6c9-cd245f85b845"));

            migrationBuilder.DropColumn(
                name: "ManufactureDate",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Supplier",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cf86b31-bf45-491f-b050-349a0dbaa6f5", "4489a8e3-141e-435b-a937-df81581ff216", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28020553-5e13-4eb6-87a9-bf19f92fec72", "3177ea33-33d9-41c8-bc01-2ff67e039c34", "Administorator", "ADMINISTRATOR" });
        }
    }
}
