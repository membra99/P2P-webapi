using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddedSubtitleToPageSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaqLists_FaqTitles_FaqTitleId",
                schema: "P2P",
                table: "FaqLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FaqTitles_Blogs_BlogId",
                schema: "P2P",
                table: "FaqTitles");

            migrationBuilder.AddColumn<string>(
                name: "PageSettingsSubtitle",
                schema: "Settings",
                table: "PagesSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FaqLists_FaqTitles_FaqTitleId",
                schema: "P2P",
                table: "FaqLists",
                column: "FaqTitleId",
                principalSchema: "P2P",
                principalTable: "FaqTitles",
                principalColumn: "FaqTitleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FaqTitles_Blogs_BlogId",
                schema: "P2P",
                table: "FaqTitles",
                column: "BlogId",
                principalSchema: "P2P",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaqLists_FaqTitles_FaqTitleId",
                schema: "P2P",
                table: "FaqLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FaqTitles_Blogs_BlogId",
                schema: "P2P",
                table: "FaqTitles");

            migrationBuilder.DropColumn(
                name: "PageSettingsSubtitle",
                schema: "Settings",
                table: "PagesSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_FaqLists_FaqTitles_FaqTitleId",
                schema: "P2P",
                table: "FaqLists",
                column: "FaqTitleId",
                principalSchema: "P2P",
                principalTable: "FaqTitles",
                principalColumn: "FaqTitleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaqTitles_Blogs_BlogId",
                schema: "P2P",
                table: "FaqTitles",
                column: "BlogId",
                principalSchema: "P2P",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
