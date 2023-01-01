using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcomerce.Server.Migrations
{
    public partial class BigUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "NewPrice", "OldPrice", "PriceChange" },
                values: new object[] { 1, 72m, 72m, new DateTime(2022, 12, 25, 22, 7, 18, 482, DateTimeKind.Local).AddTicks(8531) });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "NewPrice", "OldPrice", "PriceChange" },
                values: new object[] { 2, 2m, 2m, new DateTime(2022, 12, 25, 22, 7, 18, 482, DateTimeKind.Local).AddTicks(8564) });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "NewPrice", "OldPrice", "PriceChange" },
                values: new object[] { 3, 7m, 7m, new DateTime(2022, 12, 25, 22, 7, 18, 482, DateTimeKind.Local).AddTicks(8567) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 2, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 3, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 3, 9 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PriceId", "UserId" },
                values: new object[] { 1, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceId",
                table: "Products",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prices_PriceId",
                table: "Products",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prices_PriceId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Products_PriceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Poster" },
                    { 3, "CD" },
                    { 4, "Audiobook" },
                    { 5, "PaperBook" },
                    { 6, "MousePad" },
                    { 7, "Sticker" },
                    { 8, "NFT" },
                    { 9, "Sorce" },
                    { 10, "TEST" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 2, 19.99m, 9.99m },
                    { 1, 3, null, 7.99m },
                    { 1, 4, 29.99m, 19.99m },
                    { 2, 2, 14.99m, 7.99m },
                    { 3, 2, null, 6.99m },
                    { 4, 5, null, 3.99m },
                    { 4, 6, null, 9.99m },
                    { 4, 7, null, 19.99m },
                    { 5, 5, null, 3.99m },
                    { 6, 5, null, 2.99m },
                    { 7, 8, 29.99m, 19.99m },
                    { 7, 9, null, 69.99m },
                    { 7, 10, 59.99m, 49.99m },
                    { 8, 8, 24.99m, 9.99m },
                    { 9, 8, null, 14.99m },
                    { 10, 1, 299m, 159.99m },
                    { 11, 1, 399m, 79.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");
        }
    }
}
