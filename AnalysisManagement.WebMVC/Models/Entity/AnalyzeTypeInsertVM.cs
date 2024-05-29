using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models.Entity
{
    public class AnalyzeTypeInsertVM
    {



        [Required(AllowEmptyStrings = false, ErrorMessage = "Analiz türünün adı belirtilmelidir")]
        public string Name { get; set; }

        public string? Description { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Analizin aktif olup olmadığı belirtilmelidir")]
        public bool Active { get; set; }


    }

}
