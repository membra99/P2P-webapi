using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Faq_Pages_Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashBacks_Languages_LanguageId",
                schema: "P2P",
                table: "CashBacks");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                schema: "P2P",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                schema: "P2P",
                table: "ReviewAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                schema: "P2P",
                table: "CashBacks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Serps",
                schema: "P2P",
                columns: table => new
                {
                    SerpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    SerpTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerpDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serps", x => x.SerpId);
                    table.ForeignKey(
                        name: "FK_Serps_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                schema: "P2P",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerpId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    FacebookUrl = table.Column<int>(type: "int", nullable: true),
                    TwitterUrl = table.Column<int>(type: "int", nullable: true),
                    LinkedInUrl = table.Column<int>(type: "int", nullable: true),
                    YoutubeUrl = table.Column<int>(type: "int", nullable: true),
                    InstagramUrl = table.Column<int>(type: "int", nullable: true),
                    ReportLink = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Interest = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    SecuredBy = table.Column<int>(type: "int", nullable: true),
                    SecuredByCheck = table.Column<bool>(type: "bit", nullable: false),
                    NotSecured = table.Column<bool>(type: "bit", nullable: false),
                    Bonus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomMessage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompareButton = table.Column<bool>(type: "bit", nullable: false),
                    RiskReturn = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Usability = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Liquidity = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Support = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AutoInvest = table.Column<bool>(type: "bit", nullable: false),
                    SecondaryMarket = table.Column<bool>(type: "bit", nullable: false),
                    Promotion = table.Column<bool>(type: "bit", nullable: false),
                    MinInvestment = table.Column<int>(type: "int", nullable: true),
                    DiversificationOtherCurrency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Countries = table.Column<int>(type: "int", nullable: true),
                    LoanOriginators = table.Column<int>(type: "int", nullable: true),
                    LoanType = table.Column<int>(type: "int", nullable: true),
                    InterestRange = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MinLoanPerion = table.Column<int>(type: "int", nullable: true),
                    MaxLoanPerion = table.Column<int>(type: "int", nullable: true),
                    OperatingSince = table.Column<int>(type: "int", nullable: true),
                    Earnings = table.Column<int>(type: "int", nullable: true),
                    TotalLoanValue = table.Column<int>(type: "int", nullable: true),
                    NumberOfInvestors = table.Column<int>(type: "int", nullable: true),
                    InvestorsLoss = table.Column<int>(type: "int", nullable: true),
                    PortfolioSize = table.Column<int>(type: "int", nullable: true),
                    FinancialReport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StatisticsOtherCurrency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuybackGuarantee = table.Column<bool>(type: "bit", nullable: false),
                    PersonalGuarantee = table.Column<bool>(type: "bit", nullable: false),
                    Mortage = table.Column<bool>(type: "bit", nullable: false),
                    Collateral = table.Column<bool>(type: "bit", nullable: false),
                    NoProtection = table.Column<bool>(type: "bit", nullable: false),
                    CryptoAssets = table.Column<bool>(type: "bit", nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LiveChat = table.Column<bool>(type: "bit", nullable: false),
                    OpeningHours = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TableOfContents = table.Column<bool>(type: "bit", nullable: false),
                    CashbackBonus = table.Column<bool>(type: "bit", nullable: false),
                    DiversificationMinInvest = table.Column<int>(type: "int", nullable: true),
                    ProtectionScheme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReviewContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StatisticsCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Cryptoloan = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RatingCalculated = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NewPlatform = table.Column<bool>(type: "bit", nullable: false),
                    Recommended = table.Column<bool>(type: "bit", nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RiskAndReturn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Rev_FacebookUrlUrlTableId = table.Column<int>(type: "int", nullable: true),
                    Rev_TwitterUrlUrlTableId = table.Column<int>(type: "int", nullable: true),
                    Rev_LinkedInUrlUrlTableId = table.Column<int>(type: "int", nullable: true),
                    Rev_YoutubeUrlUrlTableId = table.Column<int>(type: "int", nullable: true),
                    Rev_InstagramUrlUrlTableId = table.Column<int>(type: "int", nullable: true),
                    Rev_ReportLinkUrlTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Serps_SerpId",
                        column: x => x.SerpId,
                        principalSchema: "P2P",
                        principalTable: "Serps",
                        principalColumn: "SerpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_UrlTables_Rev_FacebookUrlUrlTableId",
                        column: x => x.Rev_FacebookUrlUrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_UrlTables_Rev_InstagramUrlUrlTableId",
                        column: x => x.Rev_InstagramUrlUrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_UrlTables_Rev_LinkedInUrlUrlTableId",
                        column: x => x.Rev_LinkedInUrlUrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_UrlTables_Rev_ReportLinkUrlTableId",
                        column: x => x.Rev_ReportLinkUrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_UrlTables_Rev_TwitterUrlUrlTableId",
                        column: x => x.Rev_TwitterUrlUrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_UrlTables_Rev_YoutubeUrlUrlTableId",
                        column: x => x.Rev_YoutubeUrlUrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                schema: "P2P",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerpId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                    table.ForeignKey(
                        name: "FK_Pages_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pages_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalSchema: "P2P",
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pages_Serps_SerpId",
                        column: x => x.SerpId,
                        principalSchema: "P2P",
                        principalTable: "Serps",
                        principalColumn: "SerpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaqTitles",
                schema: "P2P",
                columns: table => new
                {
                    FaqTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: true),
                    ReviewId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqTitles", x => x.FaqTitleId);
                    table.ForeignKey(
                        name: "FK_FaqTitles_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "P2P",
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaqTitles_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalSchema: "P2P",
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaqLists",
                schema: "P2P",
                columns: table => new
                {
                    FaqPageListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaqTitleId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqLists", x => x.FaqPageListId);
                    table.ForeignKey(
                        name: "FK_FaqLists_FaqTitles_FaqTitleId",
                        column: x => x.FaqTitleId,
                        principalSchema: "P2P",
                        principalTable: "FaqTitles",
                        principalColumn: "FaqTitleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ReviewId",
                schema: "P2P",
                table: "Routes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAttributes_ReviewId",
                schema: "P2P",
                table: "ReviewAttributes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_CashBacks_ReviewId",
                schema: "P2P",
                table: "CashBacks",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_FaqLists_FaqTitleId",
                schema: "P2P",
                table: "FaqLists",
                column: "FaqTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_FaqTitles_PageId",
                schema: "P2P",
                table: "FaqTitles",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_FaqTitles_ReviewId",
                schema: "P2P",
                table: "FaqTitles",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DataTypeId",
                schema: "P2P",
                table: "Pages",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_LanguageId",
                schema: "P2P",
                table: "Pages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ReviewId",
                schema: "P2P",
                table: "Pages",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_SerpId",
                schema: "P2P",
                table: "Pages",
                column: "SerpId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_LanguageId",
                schema: "P2P",
                table: "Review",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Rev_FacebookUrlUrlTableId",
                schema: "P2P",
                table: "Review",
                column: "Rev_FacebookUrlUrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Rev_InstagramUrlUrlTableId",
                schema: "P2P",
                table: "Review",
                column: "Rev_InstagramUrlUrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Rev_LinkedInUrlUrlTableId",
                schema: "P2P",
                table: "Review",
                column: "Rev_LinkedInUrlUrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Rev_ReportLinkUrlTableId",
                schema: "P2P",
                table: "Review",
                column: "Rev_ReportLinkUrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Rev_TwitterUrlUrlTableId",
                schema: "P2P",
                table: "Review",
                column: "Rev_TwitterUrlUrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Rev_YoutubeUrlUrlTableId",
                schema: "P2P",
                table: "Review",
                column: "Rev_YoutubeUrlUrlTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_SerpId",
                schema: "P2P",
                table: "Review",
                column: "SerpId");

            migrationBuilder.CreateIndex(
                name: "IX_Serps_DataTypeId",
                schema: "P2P",
                table: "Serps",
                column: "DataTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashBacks_Languages_LanguageId",
                schema: "P2P",
                table: "CashBacks",
                column: "LanguageId",
                principalSchema: "P2P",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashBacks_Review_ReviewId",
                schema: "P2P",
                table: "CashBacks",
                column: "ReviewId",
                principalSchema: "P2P",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewAttributes_Review_ReviewId",
                schema: "P2P",
                table: "ReviewAttributes",
                column: "ReviewId",
                principalSchema: "P2P",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Review_ReviewId",
                schema: "P2P",
                table: "Routes",
                column: "ReviewId",
                principalSchema: "P2P",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashBacks_Languages_LanguageId",
                schema: "P2P",
                table: "CashBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_CashBacks_Review_ReviewId",
                schema: "P2P",
                table: "CashBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewAttributes_Review_ReviewId",
                schema: "P2P",
                table: "ReviewAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Review_ReviewId",
                schema: "P2P",
                table: "Routes");

            migrationBuilder.DropTable(
                name: "FaqLists",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "FaqTitles",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "Serps",
                schema: "P2P");

            migrationBuilder.DropIndex(
                name: "IX_Routes_ReviewId",
                schema: "P2P",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_ReviewAttributes_ReviewId",
                schema: "P2P",
                table: "ReviewAttributes");

            migrationBuilder.DropIndex(
                name: "IX_CashBacks_ReviewId",
                schema: "P2P",
                table: "CashBacks");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                schema: "P2P",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                schema: "P2P",
                table: "ReviewAttributes");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                schema: "P2P",
                table: "CashBacks");

            migrationBuilder.AddForeignKey(
                name: "FK_CashBacks_Languages_LanguageId",
                schema: "P2P",
                table: "CashBacks",
                column: "LanguageId",
                principalSchema: "P2P",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
