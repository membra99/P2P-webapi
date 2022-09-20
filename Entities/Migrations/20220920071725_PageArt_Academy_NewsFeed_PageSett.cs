using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class PageArt_Academy_NewsFeed_PageSett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academy",
                schema: "P2P",
                columns: table => new
                {
                    AcademyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlTableId = table.Column<int>(type: "int", nullable: false),
                    SerpId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FuturedImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TitleOverview = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Excerpt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academy", x => x.AcademyId);
                    table.ForeignKey(
                        name: "FK_Academy_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Academy_Serps_SerpId",
                        column: x => x.SerpId,
                        principalSchema: "P2P",
                        principalTable: "Serps",
                        principalColumn: "SerpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Academy_UrlTables_UrlTableId",
                        column: x => x.UrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsFeed",
                schema: "P2P",
                columns: table => new
                {
                    NewsFeedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    UrlTableId = table.Column<int>(type: "int", nullable: true),
                    NewsText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Market = table.Column<bool>(type: "bit", nullable: false),
                    RedFlag = table.Column<bool>(type: "bit", nullable: false),
                    TagLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsFeed", x => x.NewsFeedId);
                    table.ForeignKey(
                        name: "FK_NewsFeed_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsFeed_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalSchema: "P2P",
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsFeed_UrlTables_UrlTableId",
                        column: x => x.UrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagesSettings",
                schema: "Settings",
                columns: table => new
                {
                    PagesSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    SerpId = table.Column<int>(type: "int", nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesSettings", x => x.PagesSettingsId);
                    table.ForeignKey(
                        name: "FK_PagesSettings_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagesSettings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagesSettings_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalSchema: "P2P",
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagesSettings_Serps_SerpId",
                        column: x => x.SerpId,
                        principalSchema: "P2P",
                        principalTable: "Serps",
                        principalColumn: "SerpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageArticles",
                schema: "P2P",
                columns: table => new
                {
                    PageArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    AcademyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageArticles", x => x.PageArticleId);
                    table.ForeignKey(
                        name: "FK_PageArticles_Academy_AcademyId",
                        column: x => x.AcademyId,
                        principalSchema: "P2P",
                        principalTable: "Academy",
                        principalColumn: "AcademyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageArticles_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "P2P",
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academy_LanguageId",
                schema: "P2P",
                table: "Academy",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Academy_SerpId",
                schema: "P2P",
                table: "Academy",
                column: "SerpId");

            migrationBuilder.CreateIndex(
                name: "IX_Academy_UrlTableId",
                schema: "P2P",
                table: "Academy",
                column: "UrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_LanguageId",
                schema: "P2P",
                table: "NewsFeed",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_ReviewId",
                schema: "P2P",
                table: "NewsFeed",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsFeed_UrlTableId",
                schema: "P2P",
                table: "NewsFeed",
                column: "UrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_PageArticles_AcademyId",
                schema: "P2P",
                table: "PageArticles",
                column: "AcademyId");

            migrationBuilder.CreateIndex(
                name: "IX_PageArticles_PageId",
                schema: "P2P",
                table: "PageArticles",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesSettings_DataTypeId",
                schema: "Settings",
                table: "PagesSettings",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesSettings_LanguageId",
                schema: "Settings",
                table: "PagesSettings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesSettings_ReviewId",
                schema: "Settings",
                table: "PagesSettings",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesSettings_SerpId",
                schema: "Settings",
                table: "PagesSettings",
                column: "SerpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsFeed",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "PageArticles",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "PagesSettings",
                schema: "Settings");

            migrationBuilder.DropTable(
                name: "Academy",
                schema: "P2P");
        }
    }
}
