using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class HomeSettings_ReviewId_To_Platforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSettings_Review_ReviewId",
                schema: "Settings",
                table: "HomeSettings");

            migrationBuilder.DropIndex(
                name: "IX_HomeSettings_ReviewId",
                schema: "Settings",
                table: "HomeSettings");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                schema: "Settings",
                table: "HomeSettings",
                newName: "Platforms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Platforms",
                schema: "Settings",
                table: "HomeSettings",
                newName: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_ReviewId",
                schema: "Settings",
                table: "HomeSettings",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSettings_Review_ReviewId",
                schema: "Settings",
                table: "HomeSettings",
                column: "ReviewId",
                principalSchema: "P2P",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
