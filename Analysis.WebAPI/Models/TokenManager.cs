using System.Security.Claims;

namespace Analysis.WebAPI.Models
{
    public class TokenManager
    {
        //        public async Task<Token> CreateAccessToken(AppUser appUser)
        //        {

        //            Token token = new Token();
        //            token.AccessTokenExpireDate = DateTime.Now.AddMinutes(2);

        List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,"Analyst"),
                //new Claim(ClaimTypes.Email,appUser.Email)

                new Claim("CalibrationDueDate","BeforeToday"),


                //new Claim("TcNo","123123123"),
                //new Claim(ClaimTypes.Name,user.Name)
            };

        //            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Benim Super Sifrem Benim Super Sifrem Benim Super Sifrem"));

        //            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //            JwtSecurityToken securityToken = new JwtSecurityToken(
        //                issuer: "https://localhost:7144", //Bu token i kim uretti
        //                audience: "https://localhost:7144",//Bu token kimler tarafindan kullanilacak
        //                                                   //hepsiburada kullancak,n11 kullancak, kargo firmasısın diyelim. k
        //                                                   //kısıtlama getiriyoruz.
        //                                                   //su urlden gelenleri kabul et gibi yapcaz.
        //                                                   //bunu vermezsek herkes tarafından kullanılır.
        //                expires: token.AccessTokenExpireDate,
        //                notBefore: DateTime.Now,// Bu token uretildikten ne kadar sure sonra devreye girsin
        //                signingCredentials: signingCredentials,
        //                claims: claims

        //                );

        //            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //            token.AccessToken = handler.WriteToken(securityToken);
        //            token.RefreshToken = CreateRefreshToken();

        //            return token;
        //        }

        //        public string CreateRefreshToken()
        //        {
        //            byte[] number = new byte[32];
        //            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        //            {
        //                random.GetBytes(number);
        //                return Convert.ToBase64String(number);
        //            }
        //        }
    }
}

