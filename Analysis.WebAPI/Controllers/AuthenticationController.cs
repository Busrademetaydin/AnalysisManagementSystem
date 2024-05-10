using Analysis.Data.AppDbContext;
using Analysis.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Analysis.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AnalysisDbContext context;
        public AuthenticationController(UserManager<IdentityUser> userManager,
                                        RoleManager<IdentityUser> roleManager,
                                        IConfiguration configuration,
                                        AnalysisDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            this.context = context;
        }
        public IConfiguration Configuration { get; }

        [HttpPost("[action]")]
        public async Task<Token> Authentication(string email, string password)
        {
            Token token = new Token();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(email));
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("B1612-D93-TME-Loving"); // JWT'nin imzalanması için kullanılacak gizli anahtar
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, user.Id.ToString())
                        // Daha fazla isteğe bağlı bilgiyi JWT'ye ekleyebilirsiniz
                    }),
                    Expires = DateTime.UtcNow.AddDays(7), // Tokenın geçerlilik süresi
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                token.AuthenticateResult = true;
                token.AuthToken = tokenHandler.WriteToken(createdToken);
                token.AccessTokenExpireDate = createdToken.ValidTo;
                context.Update(user);
                context.SaveChanges();
                return token;
            }
            return null;
        }
    }
}
