//using Analysis.Data.AppDbContext;
//using Analysis.Entities.Concrete;
//using Analysis.WebAPI.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace Analysis.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        private readonly AnalysisDbContext context;
//        private readonly UserManager<AppUser> _userManager;


//        public LoginController(IConfiguration configuration, AnalysisDbContext context, UserManager<AppUser> userManager)
//        {
//            Configuration = configuration;
//            this.context = context;
//            _userManager = userManager;
//        }
//        public IConfiguration Configuration { get; }

//        [HttpPost("[action]")]

//        public async Task<Token> Login(string email, string password)
//        {

//            var user = context.Users.Where(p => p.Email == email).FirstOrDefault();

//            if (user != null && await _userManager.CheckPasswordAsync(user, password))
//            {
//                TokenManager tokenManager = new TokenManager();
//                Token token = await tokenManager.CreateAccessToken(user);
//                string refreshToken = tokenManager.CreateRefreshToken();

//                user.RefreshToken = token.RefreshToken;
//                user.RefreshTokenEndDate = token.AccessTokenExpireDate;

//                await _userManager.UpdateAsync(user);
//                return token;
//            }
//            else
//            {

//                return null;
//            }

//        }
//    }
//}




