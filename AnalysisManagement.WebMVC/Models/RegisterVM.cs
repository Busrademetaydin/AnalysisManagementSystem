using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class RegisterVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Identification Number must be 11 characters.")]
        public string IdentificationNumber { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password length must be at least 6 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password do not match!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}

