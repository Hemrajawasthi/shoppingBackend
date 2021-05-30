using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_tblBrand_CategoryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CategoryId",
                table: "Brands",
                newName: "IX_Brands_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_tblBrand_CategoryId",
                table: "Brands",
                column: "CategoryId",
                principalTable: "tblBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_tblBrand_CategoryId",
                table: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_CategoryId",
                table: "Users",
                newName: "IX_Users_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_tblBrand_CategoryId",
                table: "Users",
                column: "CategoryId",
                principalTable: "tblBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
