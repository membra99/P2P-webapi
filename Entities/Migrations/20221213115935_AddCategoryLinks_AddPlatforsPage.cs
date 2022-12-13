using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddCategoryLinks_AddPlatforsPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plaforms",
                schema: "P2P",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "P2P",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plaforms",
                schema: "P2P",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "P2P",
                table: "Links");
        }
    }
}
