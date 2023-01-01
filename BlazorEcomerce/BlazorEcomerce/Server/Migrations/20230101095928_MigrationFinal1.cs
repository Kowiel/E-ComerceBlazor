using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcomerce.Server.Migrations
{
    public partial class MigrationFinal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Images",
                newName: "FileData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileData",
                table: "Images",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
