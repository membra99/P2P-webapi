using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class PermissionsDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataTypeId",
                schema: "Users",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_DataTypeId",
                schema: "Users",
                table: "Permissions",
                column: "DataTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_DataTypes_DataTypeId",
                schema: "Users",
                table: "Permissions",
                column: "DataTypeId",
                principalSchema: "P2P",
                principalTable: "DataTypes",
                principalColumn: "DataTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_DataTypes_DataTypeId",
                schema: "Users",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_DataTypeId",
                schema: "Users",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DataTypeId",
                schema: "Users",
                table: "Permissions");
        }
    }
}
