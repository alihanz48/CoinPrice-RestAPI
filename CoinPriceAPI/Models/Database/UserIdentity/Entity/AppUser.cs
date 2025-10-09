using Microsoft.AspNetCore.Identity;

namespace CoinPriceAPI.Models.Database.UserIdentity.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}