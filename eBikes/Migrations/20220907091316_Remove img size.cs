using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBikes.Migrations
{
    public partial class Removeimgsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "imageSize",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "imageSize",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageSize",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imageSize",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imageSize",
                table: "Blogs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
