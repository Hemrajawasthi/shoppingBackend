using Microsoft.EntityFrameworkCore.Migrations;

namespace shopping.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCategory",
                table: "tblCategory");

            migrationBuilder.RenameTable(
                name: "tblCategory",
                newName: "tblBrand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblBrand",
                table: "tblBrand",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandName = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_tblBrand_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CategoryId",
                table: "Users",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblBrand",
                table: "tblBrand");

            migrationBuilder.RenameTable(
                name: "tblBrand",
                newName: "tblCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCategory",
                table: "tblCategory",
                column: "Id");
        }
    }
}
