using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _accountService.ValidateUser(model.Email, model.Password);
            // JWT
            // SPA (Angualar), iOS, Android
            // Json Web Token
            // If user/pss valid then we careated a Cookie, which has claims information,
            // ASP .NET can decrypt that cookie to get back original info
            // Token, (JWT) =>

            // get the claim

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("language","english"),
                new Claim( JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim( JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim( JwtRegisteredClaimNames.Email, user.Email),

            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // secret key
            // connection strings, secret keys
            // Azure KeyVault => Storing any secret information, connection string, secret keys
            var privateKey = _configuration["privateKey"];
            var expritaionTime = _configuration.GetValue<int>("expirationHours");
            var issuer = _configuration["issuer"];
            var aduience = _configuration["aduience"];

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwrExpritaionTime = DateTime.UtcNow.AddHours(expritaionTime);

            // JwrSecurityHandler
            var handler = new JwtSecurityTokenHandler();

            // describe the object to create all the information needed for token
            var tokenDescription = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = identityClaims,
                Issuer = issuer,
                Audience = aduience,
                Expires = jwrExpritaionTime,
            };

            var jwtToken = handler.CreateToken(tokenDescription);
            return Ok(new {token = handler.WriteToken(jwtToken)});

            //{"token":"asdasfgasfasfasfasdaw"}
            // 200 ok
            // if someone need secure information, buy movie. create review, favorite a movie
            // send the token in the http Header Beare
            // ASP.NET Authorize
            
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await _accountService.RegisterUser(model);
            // JWT
            return Ok(user);
        }
    }
}
