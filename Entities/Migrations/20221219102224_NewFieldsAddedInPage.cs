using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class NewFieldsAddedInPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Plaforms",
                schema: "P2P",
                table: "Pages",
                newName: "Platforms");

            migrationBuilder.AddColumn<double>(
                name: "InvestmentAmount",
                schema: "P2P",
                table: "Pages",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvestmentPeriodInMonths",
                schema: "P2P",
                table: "Pages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MonthlyContribution",
                schema: "P2P",
                table: "Pages",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvestmentAmount",
                schema: "P2P",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "InvestmentPeriodInMonths",
                schema: "P2P",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "MonthlyContribution",
                schema: "P2P",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "Platforms",
                schema: "P2P",
                table: "Pages",
                newName: "Plaforms");
        }
    }
}
