using Microsoft.EntityFrameworkCore;

namespace CoinPriceAPI.Models.Database.CoinPriceApi
{
    public class CoinPriceApiContext : DbContext
    {
        public CoinPriceApiContext(DbContextOptions<CoinPriceApiContext> options) : base(options)
        {

        }

        public DbSet<CoinModel> Coins { get; set; }
    }
}