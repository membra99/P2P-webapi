using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class DefaultCryptoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultCrypto",
                schema: "P2P",
                table: "Pages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DefaultCrypto",
                schema: "P2P",
                table: "Pages",
                column: "DefaultCrypto");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Cryptos_DefaultCrypto",
                schema: "P2P",
                table: "Pages",
                column: "DefaultCrypto",
                principalSchema: "P2P",
                principalTable: "Cryptos",
                principalColumn: "symbol",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Cryptos_DefaultCrypto",
                schema: "P2P",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_DefaultCrypto",
                schema: "P2P",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "DefaultCrypto",
                schema: "P2P",
                table: "Pages");
        }
    }
}
