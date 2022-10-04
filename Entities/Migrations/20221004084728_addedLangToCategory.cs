using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class addedLangToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                schema: "P2P",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LanguageId",
                schema: "P2P",
                table: "Categories",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Languages_LanguageId",
                schema: "P2P",
                table: "Categories",
                column: "LanguageId",
                principalSchema: "P2P",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Languages_LanguageId",
                schema: "P2P",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LanguageId",
                schema: "P2P",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "P2P",
                table: "Categories");
        }
    }
}
