using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models.Entity
{
    public class AnalystInsertVM
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analistin adı belirtilmelidir")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Analistin soyadı belirtilmelidirr")]
        public string LastName { get; set; }
        public bool? Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analistin email adresi belirtilmelidir")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analistin telefon numarası belirtilmelidir")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analistin TC Kimlik Nosu belirtilmelidir")]
        public string IdentificationNumber { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Analistin unvani belirtilmelidir")]
        public string Title { get; set; }

    }

}
