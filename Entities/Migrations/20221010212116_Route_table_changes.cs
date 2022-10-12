using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Route_table_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Review_ReviewId",
                schema: "P2P",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_ReviewId",
                schema: "P2P",
                table: "Routes");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                schema: "P2P",
                table: "Routes",
                newName: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TableId",
                schema: "P2P",
                table: "Routes",
                newName: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ReviewId",
                schema: "P2P",
                table: "Routes",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Review_ReviewId",
                schema: "P2P",
                table: "Routes",
                column: "ReviewId",
                principalSchema: "P2P",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
