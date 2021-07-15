using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorHostedIdentity.Server.Data.Migrations
{
    public partial class addAddtionalModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88da663f-d7dc-4e37-b518-2b7991605fd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd0328cb-5cd2-49c5-93a7-0cf4f7ccc526");

            migrationBuilder.CreateTable(
                name: "Declaration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerRights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declaration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declaration_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QA_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89e3c8ac-2ad2-4a51-a4fd-1cbd9eaa2b84", "2d6c5c43-449a-4b30-975f-4169f51d783d", "Visitor", "VISITOR" },
                    { "2acdf3c3-104c-4cdf-9134-f397133f71d8", "2045837f-f2dd-4cae-8a9f-e0036a49f677", "Administorator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Declaration",
                columns: new[] { "Id", "CustomerRights", "Model", "Origin", "ProductId" },
                values: new object[] { new Guid("13feebbc-ab65-4e37-aa39-fcc2ed5e5015"), "All customer rights guaranteed under consumer protection law.", "Case & Skin for Samsung Galaxy G324 149 x 70.4 x 7.8 mm", "USA", new Guid("4e693871-788d-4db4-89e5-dd7678db975e") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0102f709-1dd7-40de-af3d-23598c6bbd1f"),
                column: "ManufactureDate",
                value: new DateTime(2021, 5, 11, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d3c2abe-85ec-4d1e-9fef-9b4bfea5f459"),
                column: "ManufactureDate",
                value: new DateTime(2018, 5, 8, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("488aaa0e-aa7e-4820-b4e9-5715f0e5186e"),
                column: "ManufactureDate",
                value: new DateTime(2020, 9, 25, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4e693871-788d-4db4-89e5-dd7678db975e"),
                column: "ManufactureDate",
                value: new DateTime(2020, 10, 28, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54b2f952-b63e-4cad-8b38-c09955fe4c62"),
                column: "ManufactureDate",
                value: new DateTime(2021, 3, 12, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5567d5ac-6b3e-4627-b6c9-cd245f85b845"),
                column: "ManufactureDate",
                value: new DateTime(2020, 6, 4, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83e0aa87-158f-4e5f-a8f7-e5a98d13e3a5"),
                column: "ManufactureDate",
                value: new DateTime(2019, 9, 26, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac7de2dc-049c-4328-ab06-6cde3ebe8aa7"),
                column: "ManufactureDate",
                value: new DateTime(2018, 3, 9, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b47d4c3c-3e29-49b9-b6be-28e5ee4625be"),
                column: "ManufactureDate",
                value: new DateTime(2018, 4, 1, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1f22836-6342-480a-be2f-035eeb010fd0"),
                column: "ManufactureDate",
                value: new DateTime(2016, 8, 27, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d26384cb-64b9-4aca-acb0-4ebb8fc53ba2"),
                column: "ManufactureDate",
                value: new DateTime(2020, 1, 22, 17, 41, 51, 340, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.InsertData(
                table: "QA",
                columns: new[] { "Id", "Answer", "ProductId", "Question", "User" },
                values: new object[,]
                {
                    { new Guid("06579037-943b-4ce5-8dd6-39f34ad49329"), "Hello Brigit. You can order it online on our web shop.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), "How can I get this product", "Brigit Fansey" },
                    { new Guid("94402f9d-f280-4a7d-9c95-13e430065cee"), "Hello Mick. Yes, there is a two year guarantee for it.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), "Is there a guarantee for this product", "Mick Simons" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Comment", "ProductId", "Rate", "User" },
                values: new object[,]
                {
                    { new Guid("f43017fd-1a65-4ad1-8610-ec4154a21c87"), "I use it all the time. Excellent stuff.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), 4, "Ana Swan" },
                    { new Guid("b4031733-83a6-4d7c-b995-a3a0c0a35c39"), "Great product. Fits my phone perfectly.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), 5, "Tim Malock" },
                    { new Guid("b88bc5c2-660d-4604-ba92-69abf546e881"), "It could be better, I am not that satisfied.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), 3, "John Mining" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Declaration_ProductId",
                table: "Declaration",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QA_ProductId",
                table: "QA",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "Review",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Declaration");

            migrationBuilder.DropTable(
                name: "QA");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2acdf3c3-104c-4cdf-9134-f397133f71d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89e3c8ac-2ad2-4a51-a4fd-1cbd9eaa2b84");

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
                keyValue: new Guid("5567d5ac-6b3e-4627-b6c9-cd245f85b845"),
                column: "ManufactureDate",
                value: new DateTime(2020, 10, 23, 17, 16, 44, 30, DateTimeKind.Local).AddTicks(3887));

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
        }
    }
}
