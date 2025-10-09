using System.Threading.Tasks;
using CoinPriceAPI.DTO;
using CoinPriceAPI.Models;
using CoinPriceAPI.Models.Database;
using CoinPriceAPI.Models.Database.CoinPriceApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Mysqlx.Expr;
using Org.BouncyCastle.Asn1.Iana;
using Org.BouncyCastle.Crypto.Prng;

namespace CoinPriceAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]/market")]
    public class PriceController : ControllerBase
    {
        private CoinPriceApiContext _context;
        public PriceController(CoinPriceApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoins()
        {
            var coins = await _context.Coins.ToListAsync();

            if (coins == null)
            {
                return NotFound();
            }
            return Ok(coins);
        }

        [HttpGet]
        [Route("{value}")]
        public async Task<IActionResult> GetCoin(string value)
        {
            var coin = new CoinModel();
            if (int.TryParse(value, out int id))
            {
                coin = await _context.Coins.FirstOrDefaultAsync(c => c.coinId == id);
            }
            else
            {
                coin = await _context.Coins.FirstOrDefaultAsync(c => c.symbol == value);
            }


            if (coin == null)
            {
                return NotFound();
            }
            return Ok(coin);
        }

        [HttpGet]
        [Route("sort")]
        public async Task<IActionResult> GetSortedCoin(string variable = "coinName", string sortDirection = "asc")
        {
            bool desc = sortDirection == "desc" ? true : false;

            try
            {
                if (desc)
                {
                    return Ok(await _context.Coins.OrderByDescending(x => EF.Property<object>(x, variable)).ToListAsync());
                }
                else
                {
                    return Ok(await _context.Coins.OrderBy(x => EF.Property<object>(x, variable)).ToListAsync());
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }


        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> GetFilteredCoins(string? rate2,string variable = "price", string operatorr = ">", string rate = "100")
        {
            var dbColumns = _context.Model.FindEntityType(typeof(CoinModel)).GetProperties().Select(p => p.Name).ToList();

            if (typeof(CoinModel).GetProperties().FirstOrDefault(p => p.Name == variable).PropertyType.Name != "Decimal")   
                return BadRequest();
                
            if (!dbColumns.Contains(variable))
                return BadRequest();

            if (!new[] { "<", ">", ">=", "<=", "=" ,"between"}.Contains(operatorr))
                return BadRequest();

            if (operatorr == "between" && rate2 == null)
                return BadRequest();


            var coins = new List<CoinModel>();
            try
            {
                coins = await _context.Coins.FromSqlRaw($"SELECT * FROM coins WHERE {variable} {operatorr} {(rate2 != null ? rate + " AND " + rate2 : rate)} ").ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
            return Ok(coins);
        }

        [HttpPut]
        [Route("{value}")]
        [Authorize]
        public async Task<IActionResult> UpdateCoin(string value, coinDTO model)
        {
            var coin = new CoinModel();

            if (int.TryParse(value, out int id))
            {
                coin = await _context.Coins.FirstOrDefaultAsync(c => c.coinId == id);
            }
            else
            {
                coin = await _context.Coins.FirstOrDefaultAsync(c => c.symbol == value);
            }



            if (coin == null)
            {
                return NotFound();
            }

            coin.coinName = model.coinName;
            coin.symbol = model.symbol;
            coin.marketValue = model.marketValue;
            coin.totalMarketValue = model.totalMarketValue;
            coin.price = model.price;
            coin.usableCoin = model.usableCoin;
            coin.totalCoinCount = model.totalCoinCount;
            coin.transactionVolume = model.transactionVolume;
            coin.percentChange = model.percentChange;
            coin.coinImg = model.coinImg;

            try
            {
                var ncoin = await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return Ok(coin);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCoin(CoinModel model)
        {
            _context.Coins.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoin), new { value = model.coinId }, model);
        }

        [HttpDelete]
        [Route("{value}")]
        [Authorize]
        public async Task<IActionResult> RemoveCoin(string value)
        {
            CoinModel coin = new CoinModel();

            if (int.TryParse(value, out int id))
            {
                coin = await _context.Coins.FirstOrDefaultAsync(c => c.coinId == id);
            }
            else
            {
                coin = await _context.Coins.FirstOrDefaultAsync(c => c.symbol == value);
            }


            if (coin == null)
            {
                return NotFound();
            }

            _context.Coins.Remove(coin);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}