namespace Analysis.WebAPI.Models
{
    public class Token
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }
    }

}
