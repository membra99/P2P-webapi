using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class CashBack_Routes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashBacks",
                schema: "P2P",
                columns: table => new
                {
                    CashBackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CashBack_ca = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CashBack_terms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Valid_Until = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Exclusive = table.Column<bool>(type: "bit", nullable: true),
                    IsCampaign = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBacks", x => x.CashBackId);
                    table.ForeignKey(
                        name: "FK_CashBacks_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                schema: "P2P",
                columns: table => new
                {
                    RoutesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    UrlTableId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RoutesId);
                    table.ForeignKey(
                        name: "FK_Routes_DataTypes_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "P2P",
                        principalTable: "DataTypes",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "P2P",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_UrlTables_UrlTableId",
                        column: x => x.UrlTableId,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashBacks_LanguageId",
                schema: "P2P",
                table: "CashBacks",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DataTypeId",
                schema: "P2P",
                table: "Routes",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_LanguageId",
                schema: "P2P",
                table: "Routes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_UrlTableId",
                schema: "P2P",
                table: "Routes",
                column: "UrlTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashBacks",
                schema: "P2P");

            migrationBuilder.DropTable(
                name: "Routes",
                schema: "P2P");
        }
    }
}
