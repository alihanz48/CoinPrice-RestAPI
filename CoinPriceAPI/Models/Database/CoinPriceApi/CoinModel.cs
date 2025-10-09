using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinPriceAPI.Models.Database.CoinPriceApi
{
    public class CoinModel
    {
        [Key]
        public int? coinId { get; set; }
        public string coinName { get; set; }
        public string symbol { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal marketValue { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal totalMarketValue { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal price { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal usableCoin { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal totalCoinCount { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal transactionVolume { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal percentChange { get; set; }
        public string coinImg { get; set; }
    }
}