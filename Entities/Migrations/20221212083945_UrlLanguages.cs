using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class UrlLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlLanguages",
                schema: "P2P",
                columns: table => new
                {
                    UrlLanguagesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlLanguages", x => x.UrlLanguagesID);
                    table.ForeignKey(
                        name: "FK_UrlLanguages_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UrlLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlLanguages_DataTypeId",
                schema: "P2P",
                table: "UrlLanguages",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UrlLanguages_LanguageId",
                schema: "P2P",
                table: "UrlLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlLanguages",
                schema: "P2P");
        }
    }
}
