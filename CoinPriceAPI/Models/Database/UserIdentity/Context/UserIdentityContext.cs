
using CoinPriceAPI.Models.Database.UserIdentity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoinPriceAPI.Models.Database
{
    public class UserIdentityContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public UserIdentityContext(DbContextOptions options):base(options)
        {
            
        }
    }
}