using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Language : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                schema: "P2P",
                table: "Testimonials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "P2P",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_LanguageId",
                schema: "P2P",
                table: "Testimonials",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageName",
                schema: "P2P",
                table: "Languages",
                column: "LanguageName");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Languages_LanguageId",
                schema: "P2P",
                table: "Testimonials",
                column: "LanguageId",
                principalSchema: "P2P",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Languages_LanguageId",
                schema: "P2P",
                table: "Testimonials");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "P2P");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_LanguageId",
                schema: "P2P",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "P2P",
                table: "Testimonials");
        }
    }
}
