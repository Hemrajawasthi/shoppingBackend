using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBrand_tblCategory_CategoryId",
                table: "tblBrand");

            migrationBuilder.DropIndex(
                name: "IX_tblBrand_CategoryId",
                table: "tblBrand");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tblBrand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tblBrand",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblBrand_CategoryId",
                table: "tblBrand",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBrand_tblCategory_CategoryId",
                table: "tblBrand",
                column: "CategoryId",
                principalTable: "tblCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
