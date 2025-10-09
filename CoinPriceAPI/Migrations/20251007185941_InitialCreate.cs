using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoinPriceAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    CoinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CoinName = table.Column<string>(type: "longtext", nullable: false),
                    Symbol = table.Column<string>(type: "longtext", nullable: false),
                    MarketValue = table.Column<decimal>(type: "decimal(38,8)", nullable: false),
                    TotalMarketValue = table.Column<decimal>(type: "decimal(38,8)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38,8)", nullable: false),
                    UsableCoin = table.Column<decimal>(type: "decimal(38,8)", nullable: false),
                    TotalCoinCount = table.Column<decimal>(type: "decimal(38,8)", nullable: false),
                    TransactionVolume = table.Column<decimal>(type: "decimal(38,8)", nullable: false),
                    PercentChange = table.Column<decimal>(type: "decimal(38,8)", nullable: false),
                    CoinImg = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.CoinId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
