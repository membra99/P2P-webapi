using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class added_authors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                schema: "P2P",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                    table.ForeignKey(
                        name: "FK_Author_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_LanguageId",
                schema: "P2P",
                table: "Author",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Author_AuthorID",
                schema: "P2P",
                table: "Blogs",
                column: "AuthorID",
                principalSchema: "P2P",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Author_AuthorID",
                schema: "P2P",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "P2P");
        }
    }
}