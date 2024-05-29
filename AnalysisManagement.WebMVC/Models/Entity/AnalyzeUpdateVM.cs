using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models.Entity
{
    public class AnalyzeUpdateVM
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analizin başlama tarihi belirtilmelidir")]
        public DateOnly StartDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Analizin sona erme tarihi belirtilmelidir")]
        public DateOnly EndDate { get; set; }
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kullanılacak ekipman idsi boş bırakılamaz")]
        public int EquipmentId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analizi yapacak olan analistin idsi boş bırakılamaz")]
        public int AnalystId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Analiz türüne ait id boş bırakılamaz")]
        public int AnalyzeTypeId { get; set; }

    }

}



