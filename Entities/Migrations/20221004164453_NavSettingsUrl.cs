using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class NavSettingsUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NavigationSettings_AcademyRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "AcademyRoute");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationSettings_BonusRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "BonusRoute");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationSettings_HomeRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "HomeRoute");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationSettings_NewsRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "NewsRoute");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationSettings_ReviewsRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "ReviewsRoute");

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationSettings_UrlTables_AcademyRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "AcademyRoute",
                principalSchema: "P2P",
                principalTable: "UrlTables",
                principalColumn: "UrlTableId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationSettings_UrlTables_BonusRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "BonusRoute",
                principalSchema: "P2P",
                principalTable: "UrlTables",
                principalColumn: "UrlTableId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationSettings_UrlTables_HomeRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "HomeRoute",
                principalSchema: "P2P",
                principalTable: "UrlTables",
                principalColumn: "UrlTableId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationSettings_UrlTables_NewsRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "NewsRoute",
                principalSchema: "P2P",
                principalTable: "UrlTables",
                principalColumn: "UrlTableId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NavigationSettings_UrlTables_ReviewsRoute",
                schema: "Settings",
                table: "NavigationSettings",
                column: "ReviewsRoute",
                principalSchema: "P2P",
                principalTable: "UrlTables",
                principalColumn: "UrlTableId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NavigationSettings_UrlTables_AcademyRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_NavigationSettings_UrlTables_BonusRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_NavigationSettings_UrlTables_HomeRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_NavigationSettings_UrlTables_NewsRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_NavigationSettings_UrlTables_ReviewsRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropIndex(
                name: "IX_NavigationSettings_AcademyRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropIndex(
                name: "IX_NavigationSettings_BonusRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropIndex(
                name: "IX_NavigationSettings_HomeRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropIndex(
                name: "IX_NavigationSettings_NewsRoute",
                schema: "Settings",
                table: "NavigationSettings");

            migrationBuilder.DropIndex(
                name: "IX_NavigationSettings_ReviewsRoute",
                schema: "Settings",
                table: "NavigationSettings");
        }
    }
}
