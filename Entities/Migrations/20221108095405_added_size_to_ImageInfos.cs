using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class added_size_to_ImageInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Size",
                schema: "P2P",
                table: "ImagesInfo",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                schema: "P2P",
                table: "ImagesInfo");
        }
    }
}
