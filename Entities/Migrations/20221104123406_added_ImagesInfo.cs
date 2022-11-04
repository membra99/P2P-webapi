using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class added_ImagesInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagesInfo",
                schema: "P2P",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwsUrl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesInfo", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ImagesInfo_UrlTables_AwsUrl",
                        column: x => x.AwsUrl,
                        principalSchema: "P2P",
                        principalTable: "UrlTables",
                        principalColumn: "UrlTableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesInfo_AwsUrl",
                schema: "P2P",
                table: "ImagesInfo",
                column: "AwsUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesInfo",
                schema: "P2P");
        }
    }
}
