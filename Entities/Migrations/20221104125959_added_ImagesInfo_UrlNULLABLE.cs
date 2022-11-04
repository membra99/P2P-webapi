using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class added_ImagesInfo_UrlNULLABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AwsUrl",
                schema: "P2P",
                table: "ImagesInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AwsUrl",
                schema: "P2P",
                table: "ImagesInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
