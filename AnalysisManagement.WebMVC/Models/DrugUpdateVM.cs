using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class DrugUpdateVM
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bitmiş ürün kodu boş bırakılamaz.")]
        [MaxLength(20, ErrorMessage = "20 karakterden fazla kod içermemelidir.")]
        [RegularExpression(@"^[A-Za-z0-9\-]+$", ErrorMessage = "Ürün kodu yalnızca harf, rakam ve tire (-) içerebilir.")]
        public string ProductCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ürüne ait batch no boş bırakılamaz.")]
        public string BatchNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ürünün dozaj formu belirtilmelidir.")]
        public string DosageForm { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ürünün üretim tarihi belirtilmelidir.")]
        public DateTime MFGDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ürünün son kullanma tarihi belirtilmelidir.")]
        public DateTime EXPDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ürünün saklama koşulu belirtilmelidir.")]
        public string StorageCondition { get; set; }
    }
}


