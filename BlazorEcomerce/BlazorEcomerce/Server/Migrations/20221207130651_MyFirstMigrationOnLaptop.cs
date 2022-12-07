using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcomerce.Server.Migrations
{
    public partial class MyFirstMigrationOnLaptop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "CAtegory_C");

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 5,
                column: "URL",
                value: "Category_D");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImgURL", "Title" },
                values: new object[] { "A great Fucking Car That exists", "https://static.bhphotovideo.com/explora/sites/default/files/styles/960/public/34-trvphoto-949-00184-reduced.png?itok=4A6wlBMA", "Pojazd 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImgURL", "Title" },
                values: new object[] { "A decent Car that exists", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQDQeUbjwvSApFpWJ-EkBghl14Hwcx6vImu9VE4LzyFLKGNdB4627nZN_3e3DE8a9WXa4&usqp=CAU", "Pojazd 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "Christina_Carter");

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 5,
                column: "URL",
                value: "claire_dames");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImgURL", "Title" },
                values: new object[] { "A great Fucking pornstar", "https://porn.tattoo/pics/legaction/christina-carter/completely-free-milf-vr/christina-carter-3.jpg", "Christina Carter" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImgURL", "Title" },
                values: new object[] { "A decent Fucking pornstar", "https://external-preview.redd.it/Ti6KimBa2vh2sqPnjwPpou6S_3F440TSO8UNeFXEt1I.jpg?auto=webp&s=4653334b5fc6f001e19a5b4a556be9b103d421a1", "Claire Dames" });
        }
    }
}
