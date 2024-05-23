using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class ContactVM
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Your name is required.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Your message is required.")]
        public string Message { get; set; }


    }
}

