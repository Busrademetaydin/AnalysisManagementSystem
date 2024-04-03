using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Alani Zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Alani Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; } = false;
    }
}
