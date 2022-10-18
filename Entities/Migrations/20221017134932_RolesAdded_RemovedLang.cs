using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class RolesAdded_RemovedLang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                schema: "Users",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_LanguageId",
                schema: "Users",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "Users",
                table: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                schema: "Users",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LanguageId",
                schema: "Users",
                table: "Roles",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Languages_LanguageId",
                schema: "Users",
                table: "Roles",
                column: "LanguageId",
                principalSchema: "P2P",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
