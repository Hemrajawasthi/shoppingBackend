using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brand",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "category",
                table: "tblProduct");

            migrationBuilder.AddColumn<int>(
                name: "brandId",
                table: "tblProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "tblProduct",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brandId",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "tblProduct");

            migrationBuilder.AddColumn<int>(
                name: "brand",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
