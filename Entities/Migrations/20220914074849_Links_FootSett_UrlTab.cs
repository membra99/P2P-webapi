using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Links_FootSett_UrlTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlTables",
                schema: "P2P",
                columns: table => new
                {
                    UrlTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlTables", x => x.UrlTableId);
                    table.ForeignKey(
                        name: "FK_UrlTables_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FooterSettings",
                schema: "Settings",
                columns: table => new
                {
                    FooterSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    FacebookLink = table.Column<int>(type: "int", nullable: false),
                    LinkedInLink = table.Column<int>(type: "int", nullable: false),
                    PodcastLink = table.Column<int>(type: "int", nullable: false),
                    TwitterLink = table.Column<int>(type: "int", nullable: false),
                    YoutubeLink = table.Column<int>(type: "int", nullable: false),
                    CopyrightNotice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterSettings", x => x.FooterSettingsId);
                    table.ForeignKey(
                        name: "FK_FooterSettings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FooterSettings_UrlTables_FacebookLink",
                        column: x => x.FacebookLink,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FooterSettings_UrlTables_LinkedInLink",
                        column: x => x.LinkedInLink,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FooterSettings_UrlTables_PodcastLink",
                        column: x => x.PodcastLink,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FooterSettings_UrlTables_TwitterLink",
                        column: x => x.TwitterLink,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FooterSettings_UrlTables_YoutubeLink",
                        column: x => x.YoutubeLink,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                schema: "P2P",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlTableId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Links_UrlTables_UrlTableId",
                        column: x => x.UrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FooterSettings_FacebookLink",
                schema: "Settings",
                table: "FooterSettings",
                column: "FacebookLink");

            migrationBuilder.CreateIndex(
                name: "IX_FooterSettings_LanguageId",
                schema: "Settings",
                table: "FooterSettings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterSettings_LinkedInLink",
                schema: "Settings",
                table: "FooterSettings",
                column: "LinkedInLink");

            migrationBuilder.CreateIndex(
                name: "IX_FooterSettings_PodcastLink",
                schema: "Settings",
                table: "FooterSettings",
                column: "PodcastLink");

            migrationBuilder.CreateIndex(
                name: "IX_FooterSettings_TwitterLink",
                schema: "Settings",
                table: "FooterSettings",
                column: "TwitterLink");

            migrationBuilder.CreateIndex(
                name: "IX_FooterSettings_YoutubeLink",
                schema: "Settings",
                table: "FooterSettings",
                column: "YoutubeLink");

            migrationBuilder.CreateIndex(
                name: "IX_Links_LanguageId",
                schema: "P2P",
                table: "Links",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UrlTableId",
                schema: "P2P",
                table: "Links",
                column: "UrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_UrlTables_DataTypeId",
                schema: "P2P",
                table: "UrlTables",
                column: "DataTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterSettings",
                schema: "Settings");

            migrationBuilder.DropTable(
                name: "Links",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "UrlTables",
                schema: "P2P");
        }
    }
}
