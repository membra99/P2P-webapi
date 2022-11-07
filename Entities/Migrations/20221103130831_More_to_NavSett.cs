using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class More_to_NavSett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "More",
                schema: "Settings",
                table: "NavigationSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "More",
                schema: "Settings",
                table: "NavigationSettings");
        }
    }
}
