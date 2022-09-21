using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AboutSett_HomeSett_SettAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutSettings",
                schema: "Settings",
                columns: table => new
                {
                    AboutSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerpId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Paragraph = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TeamH2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VideoCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VideoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Section1H2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Section1H3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Section2H2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Section2Paragraph = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TestimonialH2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSettings", x => x.AboutSettingsId);
                    table.ForeignKey(
                        name: "FK_AboutSettings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AboutSettings_Serps_SerpId",
                        column: x => x.SerpId,
                        principalSchema: "P2P",
                        principalTable: "Serps",
                        principalColumn: "SerpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeSettings",
                schema: "Settings",
                columns: table => new
                {
                    HomeSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsUrl = table.Column<int>(type: "int", nullable: true),
                    ReviewId = table.Column<int>(type: "int", nullable: true),
                    ReviewUrl = table.Column<int>(type: "int", nullable: true),
                    SerpId = table.Column<int>(type: "int", nullable: true),
                    AcademyUrl = table.Column<int>(type: "int", nullable: true),
                    BonusUrl = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Returned = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Investment = table.Column<int>(type: "int", nullable: true),
                    TestimonialH2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FeaturedH2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSettings", x => x.HomeSettingsId);
                    table.ForeignKey(
                        name: "FK_HomeSettings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSettings_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalSchema: "P2P",
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSettings_Serps_SerpId",
                        column: x => x.SerpId,
                        principalSchema: "P2P",
                        principalTable: "Serps",
                        principalColumn: "SerpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSettings_UrlTables_AcademyUrl",
                        column: x => x.AcademyUrl,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSettings_UrlTables_BonusUrl",
                        column: x => x.BonusUrl,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSettings_UrlTables_NewsUrl",
                        column: x => x.NewsUrl,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSettings_UrlTables_ReviewUrl",
                        column: x => x.ReviewUrl,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SettingsAttribute",
                schema: "Settings",
                columns: table => new
                {
                    SettingsAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    SettingsDataTypeId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsAttribute", x => x.SettingsAttributeId);
                    table.ForeignKey(
                        name: "FK_SettingsAttribute_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SettingsAttribute_DataTypes_SettingsDataTypeId",
                        column: x => x.SettingsDataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SettingsAttribute_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettings_LanguageId",
                schema: "Settings",
                table: "AboutSettings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettings_SerpId",
                schema: "Settings",
                table: "AboutSettings",
                column: "SerpId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_AcademyUrl",
                schema: "Settings",
                table: "HomeSettings",
                column: "AcademyUrl");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_BonusUrl",
                schema: "Settings",
                table: "HomeSettings",
                column: "BonusUrl");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_LanguageId",
                schema: "Settings",
                table: "HomeSettings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_NewsUrl",
                schema: "Settings",
                table: "HomeSettings",
                column: "NewsUrl");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_ReviewId",
                schema: "Settings",
                table: "HomeSettings",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_ReviewUrl",
                schema: "Settings",
                table: "HomeSettings",
                column: "ReviewUrl");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSettings_SerpId",
                schema: "Settings",
                table: "HomeSettings",
                column: "SerpId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsAttribute_DataTypeId",
                schema: "Settings",
                table: "SettingsAttribute",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsAttribute_LanguageId",
                schema: "Settings",
                table: "SettingsAttribute",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsAttribute_SettingsDataTypeId",
                schema: "Settings",
                table: "SettingsAttribute",
                column: "SettingsDataTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSettings",
                schema: "Settings");

            migrationBuilder.DropTable(
                name: "HomeSettings",
                schema: "Settings");

            migrationBuilder.DropTable(
                name: "SettingsAttribute",
                schema: "Settings");
        }
    }
}
