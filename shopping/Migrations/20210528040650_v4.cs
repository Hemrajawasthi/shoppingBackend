using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropColumn(
                name: "categoryName",
                table: "tblBrand");

            migrationBuilder.DropColumn(
                name: "wearType",
                table: "tblBrand");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblBrand",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tblBrand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brandName",
                table: "tblBrand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "tblBrand",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(nullable: true),
                    wearType = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBrand_tblCategory_CategoryId",
                table: "tblBrand");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropIndex(
                name: "IX_tblBrand_CategoryId",
                table: "tblBrand");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tblBrand");

            migrationBuilder.DropColumn(
                name: "brandName",
                table: "tblBrand");

            migrationBuilder.DropColumn(
                name: "code",
                table: "tblBrand");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tblBrand",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "categoryName",
                table: "tblBrand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wearType",
                table: "tblBrand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    brandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.id);
                    table.ForeignKey(
                        name: "FK_Brands_tblBrand_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands",
                column: "CategoryId");
        }
    }
}
