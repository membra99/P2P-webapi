using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class DataType_ReviewAtr_NavSett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Settings");

            migrationBuilder.CreateTable(
                name: "DataTypes",
                schema: "P2P",
                columns: table => new
                {
                    DataTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTypes", x => x.DataTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NavigationSettings",
                schema: "Settings",
                columns: table => new
                {
                    NavigationSettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Academy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bonus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Home = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    News = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reviews = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcademyRoute = table.Column<int>(type: "int", nullable: false),
                    BonusRoute = table.Column<int>(type: "int", nullable: false),
                    HomeRoute = table.Column<int>(type: "int", nullable: false),
                    NewsRoute = table.Column<int>(type: "int", nullable: false),
                    ReviewsRoute = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationSettings", x => x.NavigationSettingsId);
                    table.ForeignKey(
                        name: "FK_NavigationSettings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewAttributes",
                schema: "P2P",
                columns: table => new
                {
                    ReviewAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewAttributes", x => x.ReviewAttributeId);
                    table.ForeignKey(
                        name: "FK_ReviewAttributes_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavigationSettings_LanguageId",
                schema: "Settings",
                table: "NavigationSettings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAttributes_DataTypeId",
                schema: "P2P",
                table: "ReviewAttributes",
                column: "DataTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavigationSettings",
                schema: "Settings");

            migrationBuilder.DropTable(
                name: "ReviewAttributes",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "DataTypes",
                schema: "P2P");
        }
    }
}
