using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class PageSett_Review_To_Platform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagesSettings_Review_ReviewId",
                schema: "Settings",
                table: "PagesSettings");

            migrationBuilder.DropIndex(
                name: "IX_PagesSettings_ReviewId",
                schema: "Settings",
                table: "PagesSettings");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                schema: "Settings",
                table: "PagesSettings");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                schema: "Settings",
                table: "PagesSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                schema: "Settings",
                table: "PagesSettings");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                schema: "Settings",
                table: "PagesSettings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagesSettings_ReviewId",
                schema: "Settings",
                table: "PagesSettings",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagesSettings_Review_ReviewId",
                schema: "Settings",
                table: "PagesSettings",
                column: "ReviewId",
                principalSchema: "P2P",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
