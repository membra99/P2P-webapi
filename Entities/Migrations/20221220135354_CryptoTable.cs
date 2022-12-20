using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class CryptoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptos",
                schema: "P2P",
                columns: table => new
                {
                    symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    supply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maxSupply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marketCapUsd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volumeUsd24Hr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priceUsd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changePercent24Hr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vwap24Hr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    explorer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.symbol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cryptos",
                schema: "P2P");
        }
    }
}
