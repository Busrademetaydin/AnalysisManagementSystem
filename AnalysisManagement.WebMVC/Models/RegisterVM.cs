using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class RegisterVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName Alani Zorunludur")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Alani Zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = " Identification Number must be 11 character.")]
        public string IdentificationNumber { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Alani Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Alani Zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}

