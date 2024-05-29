using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models.Entity
{
    public class AnalyzeDetailUpdateVM
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analiz id'si belirtilmelidir")]
        public int AnalyzeId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Analizi yapılan ürünün id'si belirtilmelidir")]
        public int DrugId { get; set; }
        public double Limit { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analize ait sonuçlar verilmelidir.")]
        public string Result { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analize ait ayrıntılar bu bölümde yer almalıdır.")]
        public string Comments { get; set; }


        public string AnalyzeType { get; set; }

    }

}
