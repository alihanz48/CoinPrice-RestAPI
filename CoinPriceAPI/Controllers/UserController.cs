using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoinPriceAPI.DTO;
using CoinPriceAPI.Models.Database;
using CoinPriceAPI.Models.Database.UserIdentity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace CoinPriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/Identity")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _Iconfiguration;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration Iconfiguration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _Iconfiguration = Iconfiguration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("\n"+model.Email+"\n");
                return BadRequest(ModelState);
            }

            var user = new AppUser
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password,
                DateAdded = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Email hatalı !" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                return Ok(new { token = GenerateJWT(user) });
            }

            return Unauthorized();
        }

        private object GenerateJWT(AppUser model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_Iconfiguration.GetSection("JwtKey:Key").Value!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()),
                new Claim(ClaimTypes.Name,model.UserName??"")
              }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "coinprice",
                Audience = "allapps"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}