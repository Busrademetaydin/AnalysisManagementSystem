using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class AnalyzeInsertVM
    {
        public int AnalyzeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kullanılacak ekipman idsi boş bırakılamaz")]
        public int EquipmentId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analizi yapacak olan analistin idsi boş bırakılamaz")]
        public int AnalystId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analiz türüne ait id boş bırakılamaz")]
        public int AnalyzeTypeId { get; set; }

    }

}
