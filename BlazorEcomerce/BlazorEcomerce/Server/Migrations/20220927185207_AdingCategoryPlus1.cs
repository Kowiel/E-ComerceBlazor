using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcomerce.Server.Migrations
{
    public partial class AdingCategoryPlus1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "Christina_Carter");

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Name", "URL" },
                values: new object[] { 5, "CD", "claire_dames" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImgURL", "Price", "Title" },
                values: new object[] { 8, 5, "A decent Fucking pornstar", "https://external-preview.redd.it/Ti6KimBa2vh2sqPnjwPpou6S_3F440TSO8UNeFXEt1I.jpg?auto=webp&s=4653334b5fc6f001e19a5b4a556be9b103d421a1", 1000000000m, "Claire Dames" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "Christina Carter");
        }
    }
}
