
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinPriceAPI.Models
{
    public class CryptoData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int rank { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal total_supply { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal max_supply { get; set; }

        [Column(TypeName = "decimal(38,8)")]
        public decimal beta_value { get; set; }
        public DateTime first_data_at { get; set; }
        public DateTime last_updated { get; set; }
        public Quotes quotes { get; set; }
    }

    public class Quotes
    {
        public USD USD { get; set; }
    }

    public class USD
    {
        [Column(TypeName ="decimal(38,8)")]
        public decimal price { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal volume_24h { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal volume_24h_change_24h { get; set; }
        
        [Column(TypeName ="decimal(38,8)")]
        public decimal market_cap { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal market_cap_change_24h { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_15m { get; set; }
        
        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_30m { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_1h { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_6h { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_12h { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_24h { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_7d { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_30d { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_change_1y { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal ath_price { get; set; }
        public DateTime ath_date { get; set; }

        [Column(TypeName ="decimal(38,8)")]
        public decimal percent_from_price_ath { get; set; }
    }

}