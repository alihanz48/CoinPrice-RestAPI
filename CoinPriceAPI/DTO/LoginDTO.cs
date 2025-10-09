using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinPriceAPI.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
       public string Password { get; set; }
    }
}