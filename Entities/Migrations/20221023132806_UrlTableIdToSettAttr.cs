using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class UrlTableIdToSettAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Settings",
                table: "SettingsAttribute",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UrlTableId",
                schema: "Settings",
                table: "SettingsAttribute",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SettingsAttribute_UrlTableId",
                schema: "Settings",
                table: "SettingsAttribute",
                column: "UrlTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingsAttribute_UrlTables_UrlTableId",
                schema: "Settings",
                table: "SettingsAttribute",
                column: "UrlTableId",
                principalSchema: "P2P",
                principalTable: "UrlTables",
                principalColumn: "UrlTableId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingsAttribute_UrlTables_UrlTableId",
                schema: "Settings",
                table: "SettingsAttribute");

            migrationBuilder.DropIndex(
                name: "IX_SettingsAttribute_UrlTableId",
                schema: "Settings",
                table: "SettingsAttribute");

            migrationBuilder.DropColumn(
                name: "UrlTableId",
                schema: "Settings",
                table: "SettingsAttribute");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Settings",
                table: "SettingsAttribute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
