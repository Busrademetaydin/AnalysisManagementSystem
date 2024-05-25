using System.Security.Claims;

namespace Analysis.WebAPI.Models
{
    public class TokenManager
    {


        List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,"Analyst"),
                //new Claim(ClaimTypes.Email,appUser.Email)

                new Claim("CalibrationDueDate","BeforeToday"),


                //new Claim("TcNo","123123123"),
                //new Claim(ClaimTypes.Name,user.Name)
            };


    }
}

