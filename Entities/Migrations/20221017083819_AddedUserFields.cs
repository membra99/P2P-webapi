using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddedUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "P2P",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                schema: "P2P",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "P2P",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LanguageId",
                schema: "P2P",
                table: "Users",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Languages_LanguageId",
                schema: "P2P",
                table: "Users",
                column: "LanguageId",
                principalSchema: "P2P",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Languages_LanguageId",
                schema: "P2P",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LanguageId",
                schema: "P2P",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "P2P",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "P2P",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "P2P",
                table: "Users");
        }
    }
}
